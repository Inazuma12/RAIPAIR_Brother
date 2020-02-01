using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void AScreenEventHandler(AScreen sender);
public class AScreen : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private Button nxtBtn;
    public event AScreenEventHandler nxtScreen;
    public Animator nxtAnimator;

    virtual protected void Start()
    {
        nxtBtn.onClick.AddListener(nextScreen);
    }

    protected void nextScreen()
    {
        nxtScreen?.Invoke(this);
    }
}
