using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private List<AScreen> allScreen;

    private void Start()
    {
        foreach (var item in allScreen)
        {
            item.nxtScreen += Item_nxtScreen;
        }
    }

    private void Item_nxtScreen(AScreen sender)
    {
        sender.animator.SetBool("GoOut", true);
        sender.animator.SetBool("GoIn", false);
        sender.animator.SetBool("Idle", false);

        sender.nxtAnimator.SetBool("GoOut", false);
        sender.nxtAnimator.SetBool("GoIn", true);
        sender.nxtAnimator.SetBool("Idle", true);

    }
}
