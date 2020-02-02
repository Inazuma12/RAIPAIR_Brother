using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBlock : DipositeBlock
{
    public override bool Diposide(PickableObject pickableObject)
    {
        if (pickableObject)
        {
            Destroy(pickableObject.gameObject);
            return true;
        }
        return false;

    }
}
