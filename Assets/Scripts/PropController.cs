using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class PropController : MonoBehaviour {

    Animator animator;
    AudioSource audio;
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public void Left()
    {
        animator.SetTrigger("Left");
        audio.pitch += 0.2f;
        StartCoroutine(LoadDelayed());
    }

    public void Right()
    {
        animator.SetTrigger("Right");
    }

    public void Straight()
    {
        animator.SetTrigger("Straight");
    }

    public void Move(IntersectionController.Direction direction)
    {
        switch (direction)
        {
            case IntersectionController.Direction.left:
                Left();
                break;
            case IntersectionController.Direction.right:
                Right();
                break;
            case IntersectionController.Direction.straight:
                Straight();
                break;
        }
    }

    IEnumerator LoadDelayed()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Primer2");
    }
}
