using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : PickableObject
{
    [SerializeField]
    ResourceInfo resourceInfo;
    public ResourceInfo ResourcesData { get => resourceInfo; set => resourceInfo = value; }

    private void OnValidate()
    {
        if (resourceInfo && SpriteRenderer)
            SpriteRenderer.sprite = resourceInfo.Sprite;
    }
}
