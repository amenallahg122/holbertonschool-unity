using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public CharacterController controller;
    public Camera mainCamera;
    public Vector3 startPosition;
    public float fallThreshold = -20f;
    public Animator animator;

    private Vector3 velocity;
    private bool isGrounded;
    private float gravity = -9.81f;
    private bool isJumping = false;
    private bool isFalling = false;
    private float airTime = 0f;
    private float jumpFallingThreshold = 2.5f;
    private float walkFallingThreshold = 0.5f;
    private bool isRecovering = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            ResetPlayerPosition();
            return;
        }

        isGrounded = controller.isGrounded;

        if (isRecovering)
        {
            CheckRecoveryState();
            
            velocity.y += gravity * Time.deltaTime;
            if (isGrounded && velocity.y < 0)
                velocity.y = -2f;
            
            controller.Move(velocity * Time.deltaTime);
            return;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            airTime = 0f;

            if (isJumping)
            {
                isJumping = false;
                animator.SetBool("isJumping", false);
            }

            if (isFalling)
            {
                isFalling = false;
                animator.SetBool("isFalling", false);
                
                animator.SetTrigger("isFallingImpact");
                isRecovering = true;
            }
        }

        if (!isGrounded)
        {
            airTime += Time.deltaTime;

            if (velocity.y < 0 && !isFalling)
            {
                if ((isJumping && airTime > jumpFallingThreshold) || 
                    (!isJumping && airTime > walkFallingThreshold))
                {
                    if (isJumping)
                    {
                        isJumping = false;
                        animator.SetBool("isJumping", false);
                    }
                    
                    isFalling = true;
                    animator.SetBool("isFalling", true);
                }
            }
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 move = forward * moveZ + right * moveX;

        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            isJumping = true;
            isFalling = false;
            airTime = 0f;
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (!isJumping && !isFalling)
        {
            animator.SetBool("isRunning", move.magnitude > 0.1f);
        }
    }

    private void CheckRecoveryState()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Getting Up") && stateInfo.normalizedTime >= 1f)
        {
            isRecovering = false;
        }
    }

    public void ResetPlayerPosition()
    {
        controller.enabled = false;
        transform.position = new Vector3(startPosition.x, startPosition.y + 10f, startPosition.z);
        velocity = Vector3.zero;
        controller.enabled = true;
    }
}