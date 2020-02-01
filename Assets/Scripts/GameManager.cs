using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void GameManagerEventHandler(GameManager sender);
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<RepairableObject> repairableObjects;
    [SerializeField] private float timeBetweenOrder;
    [SerializeField] private float timeBetweenMoneyLoss;
    [SerializeField] private float moneyLoss;

    private float _money;
    private float _score;
    private float elapsedTime;
    private float elapsedTime2;

    public float Money => _money;
    public float Score => _score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        elapsedTime2 += Time.deltaTime;

        if (elapsedTime >= timeBetweenOrder)
        {
            Random.Range(0, repairableObjects.Count);
            elapsedTime = 0;
        }

        if(elapsedTime2 >= timeBetweenMoneyLoss)
        {
            _money -= moneyLoss;
            elapsedTime2 = 0;
        }
    }
}
