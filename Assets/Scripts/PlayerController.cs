using UnityEngine;

[CreateAssetMenu(menuName = "RepairBrother/PlayerController")]
public class PlayerController : ScriptableObject {
    [SerializeField] private string _horizontalAxis;
    [SerializeField] private string _verticalAxis;

    public float HorizontalAxis
    {
        get
        {
            return Input.GetAxis(_horizontalAxis);
        }
    }

    public float VerticalAxis
    {
        get
        {
            return Input.GetAxis(_verticalAxis);
        }
    }
}
