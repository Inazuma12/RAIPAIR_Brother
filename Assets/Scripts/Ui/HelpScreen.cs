﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : AScreen
{
    [SerializeField] private Button nxtButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private Transform diapo;


    private int index = 0;

    protected void Start()
    {
        nxtBtn.onClick.AddListener(nextScreen);
        nxtButton.onClick.AddListener(NxtImage);
        prevButton.onClick.AddListener(PrevImage);
    }

    protected override void nextScreen()
    {
        base.nextScreen();
        TitleCard.fromHTP = false;
    }

    private void NxtImage()
    {
        diapo.GetChild(index).gameObject.SetActive(false);
        if (index == diapo.childCount - 1) index = 0;
        else index++;
        diapo.GetChild(index).gameObject.SetActive(true);
    }

    private void PrevImage()
    {
        diapo.GetChild(index).gameObject.SetActive(false);
        if (index == 0) index = diapo.childCount - 1;
        else index--;
        diapo.GetChild(index).gameObject.SetActive(true);
    }
}
