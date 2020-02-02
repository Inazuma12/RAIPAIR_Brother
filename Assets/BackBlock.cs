using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlock : DipositeBlock
{
    public RepairableObject repairableObject;

    public override bool Diposide(PickableObject pickableObject)
    {
         repairableObject = (RepairableObject)pickableObject;

        if (repairableObject)
        {
            GameManager.Instance.State[(int)repairableObject.state]++;


            repairableObject.transform.SetParent(transform);
            //Destroy(pickableObject.gameObject);
            return true;
        }
        return false;
    }
}
