using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickUp
{
    PickableObject PickUp();
}

public class PickUpBlock : Block , IPickUp
{
    public IPickUp PickUpBase => this;

    public override void OnInteract(Player player)
    {
    }

    PickableObject IPickUp.PickUp()
    {
        return null;
    }

}
