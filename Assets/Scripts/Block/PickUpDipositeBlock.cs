using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDipositeBlock : Block
{
    [SerializeField]
    protected PickableObject ownPickableObject = null;
    public override void OnInteract(Player player)
    {
    }


    virtual public PickableObject PickUp()
    {
        return null;
    }

    virtual public void Diposide(PickableObject pickableObject)
    {
        
    }

}
