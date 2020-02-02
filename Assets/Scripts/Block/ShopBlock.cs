using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBlock : PickUpBlock
{
    [SerializeField]
    float cooldown = 0;

    bool canPickUp = true;

    

    public Resource PickableResource
    {
        get { return ((Resource)ownPickableObject); }
    }

    IEnumerator CoolDown()
    {
        canPickUp = false;
        yield return new WaitForSeconds(cooldown);
        canPickUp = true;
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
            StartCoroutine(CoolDown());
            ownPickableObject = newPickableObject;
            return pickableObject;
        }

        return null;
    }
}
