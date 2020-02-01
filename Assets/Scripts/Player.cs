using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] bool debug;
    private Block blockToToInteract;
    private PickableObject m_pickableObject;

    public PickableObject PickableObject
    {
        get
        {
            return m_pickableObject;
        }

        set
        {
            m_pickableObject = value;
            if (m_pickableObject)
                m_pickableObject.transform.SetParent(transform);
        }
    }

    public float horizontalAxis;
    public float verticalAxis;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.HorizontalAxis != 0 || controller.VerticalAxis != 0)
        {

             horizontalAxis = controller.HorizontalAxis;
             verticalAxis = controller.VerticalAxis;
            var tmp = new Vector3(horizontalAxis, 0, verticalAxis);
            if (Mathf.Abs(horizontalAxis) > Mathf.Abs(verticalAxis))
            {
                verticalAxis = 0;
            }
            else
            {
                horizontalAxis = 0;
            }

            transform.eulerAngles = new Vector3(0, Mathf.Atan2(horizontalAxis, -verticalAxis) * Mathf.Rad2Deg, 0);
            
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Mathf.Atan2(controller.HorizontalAxis, controller.VerticalAxis) * Mathf.Rad2Deg, 0), settings.Smoothness);
            myRigidbody.velocity = transform.forward * settings.Speed;
        }

        ComputeRaycast();

        if (blockToToInteract && controller.PickUpBtn)
        {
            blockToToInteract.OnInteract(this);

            PickUpBlock pickUpBlock = blockToToInteract.GetComponent<PickUpBlock>();
            DipositeBlock dipositeBlock = blockToToInteract.GetComponent<DipositeBlock>();
            PickUpDipositeBlock pickUpDipositeBlock = blockToToInteract.GetComponent<PickUpDipositeBlock>();

            if (pickUpBlock)
            {
                PickableObject pickableObject = pickUpBlock.PickUp();
                if (pickableObject)
                    PickableObject = pickableObject;
            }

            if (dipositeBlock)
            {
                if (PickableObject)
                    dipositeBlock.Diposide(PickableObject);
            }

            if (pickUpDipositeBlock)
            {
                PickableObject pickableObject = pickUpDipositeBlock.PickUp();
                if (pickableObject)
                {
                    PickableObject = pickableObject;
                    return;
                }

                if (PickableObject)
                {
                    PickableObject.transform.SetParent(null);
                    pickUpDipositeBlock.Diposide(PickableObject);
                }
            }
        }
    }

    void ComputeRaycast()
    {
        Color color = Color.green;

        Ray ray = new Ray(transform.position, transform.forward );
        RaycastHit raycastHit;
        Physics.Raycast(ray,out raycastHit, settings.InteractionDistance);
        if (raycastHit.collider)
        {

            Block block = raycastHit.collider.GetComponent<Block>();
           
            if (block)
            {


                color = Color.red;

                blockToToInteract = block;
            }
        }
        else
            blockToToInteract = null;

        if (debug)
            Debug.DrawRay(transform.position, transform.forward* settings.InteractionDistance, color);

    }
}
