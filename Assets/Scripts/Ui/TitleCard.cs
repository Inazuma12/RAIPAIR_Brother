using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleCard : AScreen
{
    [SerializeField] private Button btnQuit;
    [SerializeField] private Button btnPlay;
    [SerializeField] private Animator hud;
    private bool alreadyCalled = false;
    static public bool fromHTP = false;
    protected void Start()
    {
        btnQuit.onClick.AddListener(OnBtnQuit);
        btnPlay.onClick.AddListener(OnBtnPlay);
        nxtBtn.onClick.AddListener(nextScreen);
    }

    protected override void nextScreen()
    {
        base.nextScreen();
        fromHTP = true;
    }

    private void OnBtnQuit()
    {
        Application.Quit();
    }

    private void OnBtnPlay()
    {
        if (fromHTP) return;
        animator.SetBool("GoOut", true);
        animator.SetBool("GoIn", false);
        animator.SetBool("Idle", false);

        hud.SetBool("GoIn", true);
        hud.SetBool("Idle", false);
        hud.SetBool("GoOut", false);

        if (!alreadyCalled)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            alreadyCalled = true;
        }

    }
}
