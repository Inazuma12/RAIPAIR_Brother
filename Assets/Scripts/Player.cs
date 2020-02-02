using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#


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
    [SerializeField, FMODUnity.EventRef]
    string footStepEvent;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

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


    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected && i == controller.playerIndex)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);

        if (state.ThumbSticks.Left.X != 0 || state.ThumbSticks.Left.Y != 0)
        {
            /*
            float angle = 0;
            if (controller.Left)
                angle = 270;
            else if (controller.Right)
                angle = 90;
            else if (controller.Up)
                angle = 0;
            else
                angle = 180;*/


            horizontalAxis = state.ThumbSticks.Left.X;
            verticalAxis = state.ThumbSticks.Left.Y;
            var tmp = new Vector3(state.ThumbSticks.Left.X, 0, state.ThumbSticks.Left.Y);
            if (Mathf.Abs(horizontalAxis) > Mathf.Abs(verticalAxis))
            {
                verticalAxis = 0;
            }
            else
            {
                horizontalAxis = 0;
            }

            forward.transform.eulerAngles = new Vector3(0, Mathf.Atan2(horizontalAxis, verticalAxis) * Mathf.Rad2Deg, 0);

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

            FMODUnity.RuntimeManager.PlayOneShot(footStepEvent, transform.position);
        }
        else
            myRigidbody.velocity = Vector3.zero;

        ComputeRaycast();

        bool pickUp = prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed;

            if (blockToToInteract && pickUp)
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
