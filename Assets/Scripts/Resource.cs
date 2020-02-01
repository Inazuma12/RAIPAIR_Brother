using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : PickableObject
{
    [SerializeField]
    ResourceInfo resourceInfo;

    private void OnValidate()
    {
        if (resourceInfo && spriteRenderer)
            spriteRenderer.sprite = resourceInfo.Sprite;
    }
}
