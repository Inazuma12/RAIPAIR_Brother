using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer spriteRenderer = null;

    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
}
