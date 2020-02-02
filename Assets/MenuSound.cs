using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    [FMODUnity.EventRef]
   public string startevent;
    [FMODUnity.EventRef]
    public string select;

    public void  PlayStartSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(startevent, transform.position);
    }

    public void PlaySelectSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(select, transform.position);
    }

}
