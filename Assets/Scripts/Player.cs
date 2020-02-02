using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] bool debug;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform forward;
    private Block blockToToInteract;
    private PickableObject m_pickableObject;
    public List<Sprite> m_sprites = new List<Sprite>();

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
                m_pickableObject.transform.SetParent(forward);
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

            forward.transform.eulerAngles = new Vector3(0, Mathf.Atan2(horizontalAxis, -verticalAxis) * Mathf.Rad2Deg, 0);

            if (forward.eulerAngles.y == 270)
            {
                if(!PickableObject)
                spriteRenderer.sprite = m_sprites[1];
                else
                    spriteRenderer.sprite = m_sprites[2];
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
                if (forward.eulerAngles.y == 90)
                {
                    if (!PickableObject)
                        spriteRenderer.sprite = m_sprites[1];
                   else
                        spriteRenderer.sprite = m_sprites[2];
                }
                if (forward.eulerAngles.y == 180)
                {
                    if (!PickableObject)
                        spriteRenderer.sprite = m_sprites[3];
                    else
                        spriteRenderer.sprite = m_sprites[0];
                }
                if (forward.eulerAngles.y == 0)
                {
                    if (!PickableObject)
                        spriteRenderer.sprite = m_sprites[5];
                    else
                        spriteRenderer.sprite = m_sprites[4];
                }
            }

            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Mathf.Atan2(controller.HorizontalAxis, controller.VerticalAxis) * Mathf.Rad2Deg, 0), settings.Smoothness);
            myRigidbody.velocity = forward.forward * settings.Speed;
        }
        else
            myRigidbody.velocity = Vector3.zero;

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
                PickableObject pickableObject = PickableObject == null ? pickUpDipositeBlock.PickUp(): null;
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

        Ray ray = new Ray(transform.position, forward.forward );
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
            Debug.DrawRay(transform.position, forward.forward* settings.InteractionDistance, color);

    }
}
