﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] bool debug;
    private Block blockToToInteract;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.HorizontalAxis != 0 || controller.VerticalAxis != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Mathf.Atan2(controller.HorizontalAxis, controller.VerticalAxis) * Mathf.Rad2Deg, 0), settings.Smoothness);
            myRigidbody.velocity += transform.forward * settings.Speed;
        }

        ComputeRaycast();

        if(blockToToInteract && controller.PickUpBtn)
        {
            blockToToInteract.OnInteract(this);
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
