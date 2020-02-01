using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableResource : PickableObject
{
    [SerializeField]
    ResourceInfo resourcesData;

    public ResourceInfo ResourcesData { get => resourcesData; set => resourcesData = value; }

    private void OnValidate()
    {
        if (ResourcesData && spriteRenderer)
        {
            spriteRenderer.sprite = ResourcesData.Sprite;
            spriteRenderer.color = resourcesData.Color;
        }
    }
}
