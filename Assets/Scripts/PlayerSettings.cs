using UnityEngine;

[CreateAssetMenu(menuName = "RepairBrother/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _smoothness;

    public float Speed => _speed * Time.deltaTime;
    public float Smoothness => _smoothness;
}
