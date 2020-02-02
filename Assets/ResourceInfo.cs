using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RepairObject
{
    CLOU,
    COLLE,
    ENGRENAGE,
    FIL,
    CIRCUIT
}

[CreateAssetMenu(menuName = "RepairBrother/Resources")]
public class ResourceInfo : ScriptableObject
{
    [SerializeField]
    RepairObject repairObject;

    [SerializeField]
    Sprite sprite;

    [SerializeField]
    float price = 1;

    [SerializeField]
    Color color = Color.white;

    [FMODUnity.EventRef]
    public string eventPickUp;

    [FMODUnity.EventRef]
    public string eventdrop;

    public RepairObject RepairObject { get => repairObject; set => repairObject = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
    public float Price { get => price; set => price = value; }
    public Color Color { get => color; set => color = value; }
}
