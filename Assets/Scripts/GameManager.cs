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
    [SerializeField] private GameObject EntryDesk;
    [SerializeField] private GameObject ExitDesk;

    public event GameManagerEventHandler OnMoneyUpdated;
    public event GameManagerEventHandler OnScoreUpdated;
    public event GameManagerEventHandler OnLose;

    private float _money;
    private float _score;
    private float elapsedTime;
    private float elapsedTime2;

    public float Money => _money;
    public float Score => _score;


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        elapsedTime2 += Time.deltaTime;

        if (elapsedTime >= timeBetweenOrder)
        {
            createOrder(Random.Range(0, repairableObjects.Count));
            elapsedTime = 0;
        }

        if(elapsedTime2 >= timeBetweenMoneyLoss)
        {
            _money -= moneyLoss;
            OnMoneyUpdated?.Invoke(this);
            elapsedTime2 = 0;
        }

        if (Money <= 0) OnLose?.Invoke(this);
    }

    private void createOrder(int objectIndex)
    {
        Instantiate(repairableObjects[objectIndex], EntryDesk.transform);
    }
}
