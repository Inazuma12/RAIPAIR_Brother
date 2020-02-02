using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBlock : PickUpBlock
{
    [SerializeField]
    float cooldown = 0;
    [SerializeField]
    Color inactived = Color.black;

    bool canPickUp = true;

    

    public Resource PickableResource
    {
        get { return ((Resource)ownPickableObject); }
    }

    IEnumerator CoolDown(PickableObject o)
    {
        ownPickableObject = o;
        Color color = ownPickableObject.SpriteRenderer.color;
        ownPickableObject.SpriteRenderer.color = inactived;
        canPickUp = false;
        yield return new WaitForSeconds(cooldown);
        canPickUp = true;
        ownPickableObject.SpriteRenderer.color = color;
    }

    public override PickableObject PickUp()
    {

        Debug.Log("PickUp");
        if (!PickableResource || !PickableResource.ResourcesData)
            return null;

        float newMoney = GameManager.Instance.Money - PickableResource.ResourcesData.Price;

        if (/*newMoney >= 0 &&*/ canPickUp)
        {
            GameManager.Instance.Money -= PickableResource.ResourcesData.Price;
            PickableObject newPickableObject = Instantiate(ownPickableObject, transform);
            PickableObject pickableObject = base.PickUp();
            StartCoroutine(CoolDown(newPickableObject));
           
            return pickableObject;
        }

        return null;
    }
}
