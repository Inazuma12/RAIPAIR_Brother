﻿using System.Collections;
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
    private List<int> _recipeToDo;
    private List<int> _piecesAlreadyPut;

    public State state;
    private bool broken;

    public List<int> RecipeToDo => _recipeToDo;
    public List<int> PiecesAlreadyPut => _piecesAlreadyPut;

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
        _recipeToDo = new List<int>() { 0,0,0};
        _piecesAlreadyPut = new List<int>();

        if (Random.value > 0.5)
        {
            _recipeToDo[0] = (int)BaseRecipe.Item1;
            _recipeToDo[1] = (int)BaseRecipe.Item2;
            _recipeToDo[2] = (int)BaseRecipe.Item3;
        }
        else
        {
            float random;
            for (int i = 0; i < 3; i++)
            {
                random = Random.value;
                if (random < BaseRecipe.Item1Probability) _recipeToDo[i] = (int)BaseRecipe.Item1;
                else if (random < BaseRecipe.Item2Probability) _recipeToDo[i] = (int)BaseRecipe.Item2;
                else if (random < BaseRecipe.Item3Probability) _recipeToDo[i] = (int)BaseRecipe.Item3;
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

    public void checkRepair(int resource)
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
