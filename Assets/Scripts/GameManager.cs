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
    [SerializeField] private ReceptBlock[] EntryDesk;
    [SerializeField] private GameObject ExitDesk;
    [SerializeField] static GameManager m_instance;

    public event GameManagerEventHandler OnMoneyUpdated;
    public event GameManagerEventHandler OnScoreUpdated;
    public event GameManagerEventHandler OnLose;
    public event GameManagerEventHandler OnOrderGenerated;

    [SerializeField]
    private float _money;
    private float _score;
    private float elapsedTime;
    private float elapsedTime2;

    private RepairableObject _newOrder;

    public RepairableObject NewOrder => _newOrder;

    public float Money
    {
        get
        {
            return _money;
        }

        set
        {
            _money = value;
            OnMoneyUpdated?.Invoke(this);
        }
    }

    public float Score => _score;

    public static GameManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    private void Awake()
    {
        m_instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (repairableObjects.Count == 0)
            return;

        elapsedTime += Time.deltaTime;
        elapsedTime2 += Time.deltaTime;

        if (elapsedTime >= timeBetweenOrder && (!EntryDesk[0].IsFull || !EntryDesk[1].IsFull))
        {
            createOrder(Random.Range(0, repairableObjects.Count));
            OnOrderGenerated(this);
            elapsedTime = 0;
        }

        if(elapsedTime2 >= timeBetweenMoneyLoss)
        {
            _money -= moneyLoss;
            elapsedTime2 = 0;
        }

        if (Money <= 0) OnLose?.Invoke(this);
    }

    private void createOrder(int objectIndex)
    {
        Transform entryDesk = EntryDesk[0].IsFull ? EntryDesk[1].transform : EntryDesk[0].transform;
        _newOrder = Instantiate(repairableObjects[objectIndex], entryDesk.position + new Vector3(0, 1), entryDesk.rotation);
    }
}
