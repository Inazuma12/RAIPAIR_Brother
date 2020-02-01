﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBlock : PickUpDipositeBlock
{
    public override PickableObject PickUp()
    {
        if (ownPickableObject == null) return null;

        PickableObject pickableObject = ownPickableObject;
        ownPickableObject = null;
        return pickableObject;
    }

    public override void Diposide(PickableObject pickableObject)
    {
        if(pickableObject.GetComponent<PickableResource>()) ownPickableObject = pickableObject;
        ownPickableObject.transform.SetParent(transform);

    }
}
