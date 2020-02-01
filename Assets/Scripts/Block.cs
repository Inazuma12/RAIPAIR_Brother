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

public enum Orientation
{
    LEFT,
    RIGHT,
    UP,
    DOWN,
    MIDDLE,
    NONE
}

public class Block : MonoBehaviour
{
    [SerializeField]
    Type _type = Type.EMPTY;
    [SerializeField]
    Transform m_parent;
    [SerializeField]
    SpriteRenderer m_spriteRenderer;
    
    public Orientation Orientation1 = Orientation.NONE;

    public Transform Parent { get => m_parent; set => m_parent = value; }
    public SpriteRenderer SpriteRenderer { get => m_spriteRenderer; set => m_spriteRenderer = value; }

    public virtual void OnInteract(Player player)
    {
    }

}
