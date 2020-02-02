using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagBlock : PickUpDipositeBlock
{
    [SerializeField] private GameObject recipeBubble;
    // Start is called before the first frame update
    public override PickableObject PickUp()
    {
        if (ownPickableObject == null) return null;

        PickableObject pickableObject = ownPickableObject;
        ownPickableObject = null;
        return pickableObject;
    }

    public override bool Diposide(PickableObject pickableObject)
    {
        if (ownPickableObject == null)
        {
            ownPickableObject = pickableObject;
            //ownPickableObject.transform.SetParent(transform);
            PrintRecipe(pickableObject);

            return true;
        }
        return false;
    }

    private void PrintRecipe(PickableObject pickableObject)
    {
        Debug.Log(pickableObject.GetComponent<RepairableObject>().RecipeToDo[0]);
        Debug.Log(pickableObject.GetComponent<RepairableObject>().RecipeToDo[1]);
        Debug.Log(pickableObject.GetComponent<RepairableObject>().RecipeToDo[2]);
    }
}
