using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlock : DipositeBlock
{
    public RepairableObject repairableObject;

    public override bool Diposide(PickableObject pickableObject)
    {
        ownPickableObject = pickableObject;
        RepairableObject repairableObject = (RepairableObject)pickableObject;

        if (repairableObject)
        {
            FMODUnity.RuntimeManager.PlayOneShot(pickableObject.eventdrop, transform.position);
            GameManager.Instance.State[(int)repairableObject.state]++;


            repairableObject.transform.SetParent(transform);
            //Destroy(pickableObject.gameObject);
            return true;
        }
        return false;
    }
}
