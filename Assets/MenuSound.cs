using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    string startevent;
    [FMODUnity.EventRef]
    string select;

    private void  PlayStartSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(startevent, transform.position);
    }

    private void PlaySelectSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(select, transform.position);
    }

}
