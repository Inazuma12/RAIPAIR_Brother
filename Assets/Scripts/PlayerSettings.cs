using UnityEngine;

[CreateAssetMenu(menuName = "RepairBrother/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed * Time.deltaTime;
    public float InteractionDistance = 2;
}
