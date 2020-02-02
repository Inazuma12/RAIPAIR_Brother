using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class HUD : MonoBehaviour
{
    static HUD instance;

    [SerializeField]
    Text scoretext;
    [SerializeField]
    Text moneyText;

    public static HUD Instance
    {
        get
        {
            return instance;
        }
       
    }

    private void Awake()
    {
        instance = this;
    }

    public float Score
    {
        set
        {
            if(scoretext)
            scoretext.text = value.ToString();
        }
    }

    public float Money
    {
        set
        {
            if (scoretext)
                moneyText.text = value.ToString();
        }
    }
}
