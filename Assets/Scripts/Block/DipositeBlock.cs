﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DipositeBlock : Block 
{
    public override void OnInteract(Player player)
    {
    }

    public virtual bool Diposide(PickableObject pickableObject)
    {
        return false;
    }
}