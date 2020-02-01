using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptBlock : PickUpBlock
{
    private bool _isFull = false;

    public bool IsFull => _isFull;
    
    private void Start()
    {
        GameManager.Instance.OnOrderGenerated += Instance_OnOrderGenerated;
    }

    private void Instance_OnOrderGenerated(GameManager sender)
    {
        if (IsFull) return;
        
        ownPickableObject = sender.NewOrder;
        _isFull = true;
    }

    public PickableObject PickableResource
    {
        get { return ownPickableObject; }
    }

    public override PickableObject PickUp()
    {
        if (!PickableResource) return null;

        PickableObject pickableObject = ownPickableObject;
        ownPickableObject = null;
        return pickableObject;

    }
}
