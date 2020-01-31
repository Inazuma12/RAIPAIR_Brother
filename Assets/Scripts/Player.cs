using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSettings settings;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(controller.HorizontalAxis * settings.Speed, 0, controller.VerticalAxis * settings.Speed);

        transform.position += velocity;
    }
}
