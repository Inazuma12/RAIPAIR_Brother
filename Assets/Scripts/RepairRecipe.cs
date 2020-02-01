 using UnityEngine;
[CreateAssetMenu(menuName = "RepairBrother/RepairRecipe")]

public class RepairRecipe : ScriptableObject
{
    [SerializeField] Sprite _repairSprite = null;
    [SerializeField] Sprite _toRepaireSprite = null;
    [SerializeField] Sprite _destorySprite = null;


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

    public Sprite RepairSprite { get => _repairSprite; set => _repairSprite = value; }
    public Sprite ToRepaireSprite { get => _toRepaireSprite; set => _toRepaireSprite = value; }
    public Sprite DestorySprite { get => _destorySprite; set => _destorySprite = value; }
}
