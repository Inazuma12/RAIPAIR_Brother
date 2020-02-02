using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlock : DipositeBlock
{
    public override bool Diposide(PickableObject pickableObject)
    {
        RepairableObject repairableObject = (RepairableObject)pickableObject;

        if (repairableObject)
        {
            GameManager.Instance.State[(int)repairableObject.state]++;

            GameManager.Instance.Money += GameManager.Instance.MoneyToAdd[(int)repairableObject.state];

            Destroy(pickableObject.gameObject);
            return true;
        }
        return false;
    }
}
