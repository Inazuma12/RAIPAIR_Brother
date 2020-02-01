using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RepairObject
{
    CLOU = 1,
    COLLE = 2,
    ENGRENAGE = 3,
    FIL = 4,
    CIRCUIT = 5
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

    public RepairObject RepairObject { get => repairObject; set => repairObject = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
    public float Price { get => price; set => price = value; }
    public Color Color { get => color; set => color = value; }
}
