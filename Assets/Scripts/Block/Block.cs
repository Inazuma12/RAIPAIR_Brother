using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Type
{
    REPAIR = 0,
    TRASH,
    COUNTER_BACK,
    COUNTER_STORAGE,
    WALL,
    COUNTER_RECEPT,
    SHOP,
    EMPTY,
    DIAGNOSTIC
}

public class Block : MonoBehaviour
{
    [SerializeField]
    Type _type = Type.EMPTY;

    public virtual void OnInteract(Player player)
    {
    }

}
