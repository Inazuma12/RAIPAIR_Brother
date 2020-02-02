using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeModel : MonoBehaviour
{
    public PickableObject pickableObject;
    public GameObject modelToShake;
    public bool wasShake = false;
    public Vector3 modelTransformBefore;
    public float shakeAmount = 0.2f;
    public float decreaseFactor = 1.0f;

    // Update is called once per frame
    void Update()
    {
        PickUpDipositeBlock pickUpBlock = GetComponentInParent<PickUpDipositeBlock>();
        DipositeBlock dipositeBlock = GetComponentInParent<DipositeBlock>();
        PickUpDipositeBlock pickUpDipositeBlock = GetComponentInParent<PickUpDipositeBlock>();


        if (pickUpBlock)
            pickableObject = pickUpBlock.ownPickableObject;
        else if(dipositeBlock)
                pickableObject = dipositeBlock.ownPickableObject;
        else if (pickUpDipositeBlock)
            pickableObject = pickUpDipositeBlock.ownPickableObject;

        if (!(wasShake) && pickableObject != null)
        {
            modelTransformBefore = modelToShake.transform.position;
            StartCoroutine(_modelShake(0.1f));
            wasShake = true;
            pickableObject.transform.position = new Vector3(transform.position.x, pickableObject.transform.position.y, transform.position.z);
        }
        if (pickableObject == null)
        {
            wasShake = false;
        }
    }

    IEnumerator _modelShake(float shakeDuration)
    {
        while (shakeDuration > 0)
        {
            modelToShake.transform.position = new Vector3( modelTransformBefore.x + Random.Range(-shakeAmount * shakeDuration, shakeAmount * shakeDuration),
                                                           modelTransformBefore.y + Random.Range(-shakeAmount * shakeDuration, shakeAmount * shakeDuration),
                                                           modelTransformBefore.z);
            shakeDuration -= Time.deltaTime * decreaseFactor;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Debug.Log("yolo");
        modelToShake.transform.position = modelTransformBefore;
    }
}
