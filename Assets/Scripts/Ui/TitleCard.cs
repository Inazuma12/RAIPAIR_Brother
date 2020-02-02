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
    override protected void Start()
    {
        base.Start();
        btnQuit.onClick.AddListener(OnBtnQuit);
        btnPlay.onClick.AddListener(OnBtnPlay);

    }

    private void OnBtnQuit()
    {
        Application.Quit();
    }

    private void OnBtnPlay()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
       

        animator.SetBool("GoOut", true);
        animator.SetBool("GoIn", false);
        animator.SetBool("Idle", false);

        hud.SetBool("GoIn", true);
        hud.SetBool("Idle", false);
        hud.SetBool("GoOut", false);

    }
}
