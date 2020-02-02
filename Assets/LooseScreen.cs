using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LooseScreen : AScreen
{
    public Text scoreText;
    public Text temps;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Lose()
    {
        gameObject.SetActive(true);
        animator.SetBool("Goin", true);
        animator.SetBool("idle", false);
        animator.SetBool("Goout", false);

        
       
    }


    public void NextBu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
