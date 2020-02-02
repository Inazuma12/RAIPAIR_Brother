using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagBlock : PickUpDipositeBlock
{
    [SerializeField] private GameObject feedBackPrefab;
    [SerializeField] private ResourceInfo[] resourceSprite;

    private GameObject feedback;

    [FMODUnity.EventRef]
    string diagEvent;

    // Start is called before the first frame update
    public override PickableObject PickUp()
    {
        if (ownPickableObject == null) return null;

        PickableObject pickableObject = ownPickableObject;
        ownPickableObject = null;
        Destroy(feedback);
        return pickableObject;
    }

    public override bool Diposide(PickableObject pickableObject)
    {
        if (ownPickableObject == null)
        {
            FMODUnity.RuntimeManager.PlayOneShot(diagEvent, transform.position);
            ownPickableObject = pickableObject;
            ownPickableObject.transform.SetParent(transform);
            PrintRecipe(pickableObject);

            return true;
        }
        return false;
    }

    private void PrintRecipe(PickableObject pickableObject)
    {
        feedback = Instantiate(feedBackPrefab);
        SpriteRenderer image;
        for (int i = 0; i < 3; i++)
        {
            image = feedback.transform.GetChild(0).GetChild(i).GetComponent<SpriteRenderer>();
            Debug.Log(image);
            if (pickableObject.GetComponent<RepairableObject>().RecipeToDo[i] == (int)RepairObject.CIRCUIT)
                image.sprite = resourceSprite[0].Sprite;
            else if (pickableObject.GetComponent<RepairableObject>().RecipeToDo[i] == (int)RepairObject.CLOU)
                image.sprite = resourceSprite[1].Sprite;
            else if (pickableObject.GetComponent<RepairableObject>().RecipeToDo[i] == (int)RepairObject.COLLE)
                image.sprite = resourceSprite[2].Sprite;
            else if (pickableObject.GetComponent<RepairableObject>().RecipeToDo[i] == (int)RepairObject.ENGRENAGE)
                image.sprite = resourceSprite[3].Sprite;
            else if (pickableObject.GetComponent<RepairableObject>().RecipeToDo[i] == (int)RepairObject.FIL)
                image.sprite = resourceSprite[4].Sprite;
        }
    }
}
