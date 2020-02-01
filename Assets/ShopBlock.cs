using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBlock : PickUpBlock, IPickUp
{
    PickableObject IPickUp.PickUp()
    {
        float money = 0;
        return PickUpBase.PickUp();
    }
}
