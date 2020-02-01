using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerSettings settings;

    private Vector3 velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(controller.VerticalAxis, controller.HorizontalAxis) * 180 / Mathf.PI, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        float pen = 0;
        Vector3 normal = new Vector3();
        foreach (var item in collision.contacts)
        {
            if (item.separation < 0 && item.separation > -1) pen += item.separation;
            normal += item.normal;
        }
        //Debug.Log(pen);
        transform.position -= normal.normalized * pen * settings.Speed;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        int count = collision.contactCount;

        for (int i = 0; i < count; i++)
        {
            penetration += collision.GetContact(i).separation;
            normal += collision.GetContact(i).normal * penetration;
            
        }
        normal = normal.normalized;
        
    }*/

    /*private void OnCollisionExit(Collision collision)
    {
        normal = new Vector3();
        penetration = 0;
    }*/

}
