 using UnityEngine;
[CreateAssetMenu(menuName = "RepairBrother/RepairRecipe")]

public class RepairRecipe : ScriptableObject
{
    public enum RepairObject
    {
        CLOU = 1,
        COLLE = 2,
        ENGRENAGE = 3,
        FIL = 4,
        CIRCUIT = 5,
    };

    [SerializeField] private RepairObject _item1;
    [SerializeField] private RepairObject _item2;
    [SerializeField] private RepairObject _item3;
    [SerializeField] private float _item1probability;
    [SerializeField] private float _item2probability;
    [SerializeField] private float _item3probability;

    public RepairObject Item1 => _item1;
    public RepairObject Item2 => _item2;
    public RepairObject Item3 => _item3;

    public float Item1Probability => _item1probability;
    public float Item2Probability => _item2probability;
    public float Item3Probability => _item3probability;
    
}
