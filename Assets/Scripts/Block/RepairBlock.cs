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
            FMODUnity.RuntimeManager.PlayOneShot(pickableObject.eventdrop, transform.position);
            ownPickableObject = pickableObject;
            ownPickableObject.transform.SetParent(this.transform);
            return true;
        }

        if(ownPickableObject != null && pickableObject.GetComponent<Resource>() != null)
        {
            ownPickableObject.GetComponent<RepairableObject>().checkRepair(pickableObject.GetComponent<Resource>().ResourcesData.RepairObject);
            Destroy(pickableObject.gameObject);
            return true;
        }

        return false;
    }
}
