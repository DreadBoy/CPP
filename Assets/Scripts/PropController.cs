using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PropController : MonoBehaviour {

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Left()
    {
        animator.SetTrigger("Left");
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
}
