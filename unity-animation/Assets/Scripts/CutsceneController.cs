using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Animator animator;
    public Camera cutsceneCamera;
    public Camera mainCamera;
    public GameObject player;
    public PlayerMovement playerController;
    public GameObject timerCanvas;

    void Start()
    {
        if (animator != null)
        {
            if (animator.HasState(0, Animator.StringToHash("Intro01")))
            {
                animator.Play("Intro01", 0);
                if (playerController != null)
                {
                    playerController.enabled = false;
                }

                if (timerCanvas != null)
                {
                    timerCanvas.SetActive(false);
                }

                StartCoroutine(SwitchToGameplay());
            }
            else
            {
            }
        }
        else
        {
        }
    }

    private System.Collections.IEnumerator SwitchToGameplay()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;
        Debug.Log("Animation Length: " + animationLength);

        if (animationLength > 0)
        {
            yield return new WaitForSeconds(animationLength);
        }

        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);
        }

        if (playerController != null)
        {
            playerController.enabled = true;
        }

        if (timerCanvas != null)
        {
            timerCanvas.SetActive(true);
        }

        if (cutsceneCamera != null)
        {
            cutsceneCamera.gameObject.SetActive(false);
        }

        this.gameObject.SetActive(false);
    }
}
