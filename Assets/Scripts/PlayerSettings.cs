using UnityEngine;

[CreateAssetMenu(menuName = "RepairBrother/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _interactionDistance;

    public float Speed => _speed * Time.deltaTime;
    public float InteractionDistance => _interactionDistance;

}
