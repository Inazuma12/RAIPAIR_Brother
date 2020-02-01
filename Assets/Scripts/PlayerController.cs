using UnityEngine;

[CreateAssetMenu(menuName = "RepairBrother/PlayerController")]
public class PlayerController : ScriptableObject {
    [SerializeField] private string _horizontalAxis;
    [SerializeField] private string _verticalAxis;
    [SerializeField] private string _pickUpBtn;

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

    public bool PickUpBtn
    {
        get
        {
            return Input.GetButton(_pickUpBtn);
        }
    }
}
