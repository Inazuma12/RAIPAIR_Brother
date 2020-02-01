using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiposide
{
    void Diposide(PickableObject pickableObject);
}

public class DipositeBlock : Block , IDiposide
{
    public override void OnInteract(Player player)
    {
    }

    void IDiposide.Diposide(PickableObject pickableObject)
    {
        
    }
}
