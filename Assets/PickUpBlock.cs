using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpBlock : Block 
{
    [SerializeField]
    protected PickableObject ownPickableObject = null;

   

    public override void OnInteract(Player player)
    {
    }

    public virtual PickableObject PickUp()
    {
        PickableObject pickableObject = ownPickableObject;
        ownPickableObject = null;
        return pickableObject;

    }

}
