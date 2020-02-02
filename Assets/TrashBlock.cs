using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBlock : DipositeBlock
{
    [FMODUnity.EventRef]
    string trashEvent;

    public override bool Diposide(PickableObject pickableObject)
    {
        if (pickableObject)
        {
            FMODUnity.RuntimeManager.PlayOneShot(trashEvent, transform.position);
            GameManager.Instance.objectTrash++;
            Destroy(pickableObject.gameObject);
            return true;
        }
        return false;

    }
}
