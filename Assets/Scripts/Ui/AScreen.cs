using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AScreen : MonoBehaviour
{
    public Animator animator;
    [SerializeField] protected Button nxtBtn;
    public Animator nxtAnimator;

    virtual protected void nextScreen()
    {
        animator.SetBool("GoOut", true);
        animator.SetBool("GoIn", false);
        animator.SetBool("Idle", false);

        nxtAnimator.SetBool("GoOut", false);
        nxtAnimator.SetBool("GoIn", true);
        nxtAnimator.SetBool("Idle", true);
    }
}
