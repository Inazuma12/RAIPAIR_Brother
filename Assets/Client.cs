using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Client : MonoBehaviour
{
    public Transform start;
    public Transform end;

    public float timeToEnter = 10;
    public float timeToExit = 10;
    public float timeTowait = 10;
    public float timeTowait2 = 10;

    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public UnityEvent OnWait;
    public UnityEvent OnWait2;

    public Sprite enter;
    public Sprite exit;

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        Enter();
    }

    public void Enter()
    {
    
        StartCoroutine(EnterCorotine());
        if(spriteRenderer)
        spriteRenderer.sprite = enter;
        


    }

    public void Exit()
    {
        StartCoroutine(EndCorotine());
        if (spriteRenderer)
            spriteRenderer.sprite = exit;

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeTowait);
        Exit();
        OnExit.Invoke();
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(timeTowait2);
        Enter();
    }

    IEnumerator EnterCorotine()
    {
        yield return LerpCorotine(start, end, timeToEnter);
        OnEnter.Invoke();

        yield return StartCoroutine(Wait());
    }

    IEnumerator EndCorotine()
    {
        yield return LerpCorotine(end, start, timeToExit);

        yield return StartCoroutine(Wait2());
    }

    IEnumerator LerpCorotine(Transform begin, Transform last,float time)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(begin.position, last.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }


    }
}
