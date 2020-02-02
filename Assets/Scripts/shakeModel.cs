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
        try
        {
            pickableObject = GetComponentInParent<PickUpDipositeBlock>().ownPickableObject;
        }
        catch (System.Exception)
        {
            try
            {
                pickableObject = GetComponentInParent<DipositeBlock>().ownPickableObject;
            }
            catch (System.Exception)
            {
                pickableObject = GetComponentInParent<PickUpBlock>().ownPickableObject;
            }
        }
        if (!(wasShake) && pickableObject != null)
        {
            modelTransformBefore = modelToShake.transform.position;
            StartCoroutine(_modelShake(0.1f));
            wasShake = true;
            pickableObject.transform.position = new Vector3(transform.position.x, transform.position.y, pickableObject.transform.position.z);
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
