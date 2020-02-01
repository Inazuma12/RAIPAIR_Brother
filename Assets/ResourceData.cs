using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RepairObject
{
    CLOU = 1,
    COLLE = 2,
    ENGRENAGE = 3,
    FIL = 4,
    CIRCUIT = 5,
};

[CreateAssetMenu(menuName = "RepairBrother/Resources")]
public class ResourcesData : ScriptableObject
{
    RepairObject repairObject;
    Sprite sprite;

    public RepairObject RepairObject { get => repairObject; set => repairObject = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
}
