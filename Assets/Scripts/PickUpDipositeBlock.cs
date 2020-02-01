using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDipositeBlock : Block, IPickUp, IDiposide
{
    public override void OnInteract(Player player)
    {
    }


    PickableObject IPickUp.PickUp()
    {
        return null;
    }

    void IDiposide.Diposide(PickableObject pickableObject)
    {

    }

}
