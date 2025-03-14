using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Animator animator;
    public Camera CutsceneCamera;
    public Camera MainCamera;

    void Start()
    {
        // Start the cutscene animation
        animator.Play("Intro01");
        StartCoroutine(SwitchCameraAfterAnimation());
    }

    private IEnumerator SwitchCameraAfterAnimation()
    {
        // Wait until the animation finishes
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Switch cameras
        CutsceneCamera.gameObject.SetActive(false);
        MainCamera.gameObject.SetActive(true);
    }
}
