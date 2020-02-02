using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    REPAIR0,
    REPAIR1,
    REPAIR2,
    FIXED,
    BROKEN
}

public class RepairableObject : PickableObject
{
    [SerializeField] private RepairRecipe baseRecipe;
    private List<RepairObject> _recipeToDo;
    private List<RepairObject> _piecesAlreadyPut;

    public State state;
    private bool broken;

    public List<RepairObject> RecipeToDo => _recipeToDo;
    public List<RepairObject> PiecesAlreadyPut => _piecesAlreadyPut;

    public RepairRecipe BaseRecipe { get => baseRecipe; set => baseRecipe = value; }
    [FMODUnity.EventRef] public string repairEvent;
    private void OnValidate()
    {
        if (BaseRecipe && SpriteRenderer)
        {
            SpriteRenderer.sprite = BaseRecipe.ToRepaireSprite;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _recipeToDo = new List<RepairObject>();
        _piecesAlreadyPut = new List<RepairObject>();

        if (Random.value > 0.5)
        {
            _recipeToDo.Add(BaseRecipe.Item1);
            _recipeToDo.Add(BaseRecipe.Item2);
            _recipeToDo.Add(BaseRecipe.Item3);
        }
        else
        {
            float random;
            for (int i = 0; i < 3; i++)
            {
                random = Random.value;
                if (random < BaseRecipe.Item1Probability) _recipeToDo.Add(BaseRecipe.Item1);
                else if (random < BaseRecipe.Item2Probability) _recipeToDo.Add(BaseRecipe.Item2);
                else if (random < BaseRecipe.Item3Probability) _recipeToDo.Add(BaseRecipe.Item3);
            }
        }
    }

    private void Update()
    {
        if (broken)
        {
            state = State.BROKEN;
            SpriteRenderer.sprite = baseRecipe.DestorySprite;
        }
        else if (PiecesAlreadyPut.Count == 0) state = State.REPAIR0;
        else if (PiecesAlreadyPut.Count == 1) state = State.REPAIR1;
        else if (PiecesAlreadyPut.Count == 2) state = State.REPAIR2;
        else if (PiecesAlreadyPut.Count == 3)
        {
            state = State.FIXED;
            SpriteRenderer.sprite = BaseRecipe.RepairSprite;
        }
    }

    public void checkRepair(RepairObject resource)
    {
        for (int i = 0; i < _recipeToDo.Count; i++)
        {
            if(_recipeToDo[i] == resource)
            {
                FMODUnity.RuntimeManager.PlayOneShot(repairEvent, transform.position);
                _piecesAlreadyPut.Add(resource);
                return;
            }
        }
        broken = true;
    }
}
