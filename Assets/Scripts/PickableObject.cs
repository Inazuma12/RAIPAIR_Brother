using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string eventPickUp;

    [FMODUnity.EventRef]
    public string eventdrop;

    [SerializeField]
    public SpriteRenderer spriteRenderer = null;

    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
}
