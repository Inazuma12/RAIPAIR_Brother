using System.Collections;
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

    public override bool Diposide(PickableObject pickableObject)
    {
        if(pickableObject.GetComponent<RepairableObject>())
        {
            ownPickableObject = pickableObject;
            ownPickableObject.transform.SetParent(this.transform);
            return true;
        }

        if(ownPickableObject != null && pickableObject.GetComponent<Resource>() != null)
        {
            ownPickableObject.GetComponent<RepairableObject>().checkRepair((int)pickableObject.GetComponent<Resource>().ResourcesData.RepairObject);
            Destroy(pickableObject.gameObject);
            return true;
        }

        return false;
    }
}
