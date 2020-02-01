using UnityEngine;

[CreateAssetMenu(menuName = "RepairBrother/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _smoothness;

    public float Speed => _speed * Time.deltaTime;
<<<<<<< HEAD
    public float Smoothness => _smoothness;
=======
    public float InteractionDistance = 2;
>>>>>>> 029e512d03ccdba675e9abdbcec676fbda0308b4
}
