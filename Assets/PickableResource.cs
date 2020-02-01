using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableResource : PickableObject
{
    [SerializeField]
    ResourcesData resourcesData;

    private void OnValidate()
    {
        if (resourcesData && spriteRenderer)
            spriteRenderer.sprite = resourcesData.Sprite;
    }
}
