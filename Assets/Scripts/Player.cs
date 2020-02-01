using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSettings settings;

    private Vector3 velocity;
    private bool isMobile = true;
    
    private bool isleft = true;
    private bool isRight = true;
    private bool isUp = true;
    private bool isDown = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMobile) velocity = new Vector3(controller.HorizontalAxis * settings.Speed, 0, controller.VerticalAxis * settings.Speed);
        else if (!isMobile && isleft && controller.HorizontalAxis > 0) velocity = new Vector3(controller.HorizontalAxis * settings.Speed, 0, 0);
        else if (!isMobile && isRight && controller.HorizontalAxis < 0) velocity = new Vector3(controller.HorizontalAxis * settings.Speed, 0, 0);
        else if (!isMobile && isUp && controller.VerticalAxis < 0)
        {
            velocity = new Vector3(0, 0, controller.VerticalAxis * settings.Speed);
        }
        else if (!isMobile && isDown && controller.VerticalAxis > 0)
        {
            velocity = new Vector3(0, 0, controller.VerticalAxis * settings.Speed);
        }
        else velocity = new Vector3();

        Debug.Log(controller.VerticalAxis);
        transform.position += velocity;
    }

    private void OnTriggerEnter(Collider other) 
    {
        Block collider;
        isMobile = false;
        
        if(other.CompareTag("Block"))
        {
            collider = other.gameObject.GetComponent<Block>();
            
            isleft = collider.Orientation1 == Orientation.LEFT ? true : false;
            
            isRight = collider.Orientation1 == Orientation.RIGHT ? true : false;
            
            isUp = collider.Orientation1 == Orientation.UP ? true : false;
           
            isDown = collider.Orientation1 == Orientation.DOWN ? true : false;

            if (collider.Orientation2 != Orientation.NONE)
            {
                isUp = collider.Orientation2 == Orientation.UP ? true : false;
                isDown = collider.Orientation2 == Orientation.DOWN ? true : false;
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        isMobile = true;
        isleft = false;
        isRight = false;
        isUp = false;
        isDown = false;
    }
}
