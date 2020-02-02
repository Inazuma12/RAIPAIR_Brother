using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBlock : PickUpDipositeBlock
{
    public PickableObject objectOnStorage;
    public override PickableObject PickUp()
    {
        if (ownPickableObject == null) return null;

        PickableObject pickableObject = ownPickableObject;
        ownPickableObject = null;
        objectOnStorage = ownPickableObject;
        return pickableObject;
    }

    public override bool Diposide(PickableObject pickableObject)
    {
        if (ownPickableObject == null)
        {
            ownPickableObject = pickableObject;
            ownPickableObject.transform.SetParent(transform);
            objectOnStorage = ownPickableObject;
            return true;
        }
        return false;
    }

}
