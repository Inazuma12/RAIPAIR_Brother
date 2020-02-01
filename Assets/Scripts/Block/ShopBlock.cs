using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBlock : PickUpBlock
{
    [SerializeField]
    float cooldown = 0;

    bool canPickUp = true;

    public bool CanPickUp
    {
        get
        {
            return canPickUp;
        }

        set
        {
            if (canPickUp && !value)
            {
                ownPickableObject = Instantiate(ownPickableObject, transform);
                StartCoroutine(CoolDown());
            }
            canPickUp = value;
        }
    }

    public PickableResource PickableResource
    {
        get { return ((PickableResource)ownPickableObject); }
    }

    IEnumerator CoolDown()
    {
        CanPickUp = false;
        yield return new WaitForSeconds(cooldown);
        CanPickUp = true;
    }

    public override PickableObject PickUp()
    {

        Debug.Log("PickUp");
        if (!PickableResource || !PickableResource.ResourcesData)
            return null;

        float newMoney = GameManager.Instance.Money - PickableResource.ResourcesData.Price;

        if (newMoney >= 0 && CanPickUp)
        {
            GameManager.Instance.Money -= PickableResource.ResourcesData.Price;
            PickableObject newPickableObject = Instantiate(ownPickableObject, transform);
            PickableObject pickableObject = base.PickUp();
            CanPickUp = true;
            ownPickableObject = newPickableObject;
            return pickableObject;
        }

        return null;
    }
}
