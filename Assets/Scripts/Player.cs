using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSettings settings;

    private Vector3 velocity;
    private bool isMobile = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(controller.HorizontalAxis * settings.Speed, 0, controller.VerticalAxis * settings.Speed );

        if (isMobile) transform.position += velocity;
        else if (!isMobile && controller.VerticalAxis < 0) transform.position += new Vector3(0, 0, controller.VerticalAxis * settings.Speed);
        else if (!isMobile) transform.position += new Vector3(controller.HorizontalAxis * settings.Speed, 0, 0);
    }

    private void OnTriggerEnter(Collider other) 
    { 
        isMobile = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isMobile = true;
    }
}
