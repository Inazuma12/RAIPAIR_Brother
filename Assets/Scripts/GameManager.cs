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
    [SerializeField] private BackBlock ExitDesk;
    [SerializeField] static GameManager m_instance;

    public event GameManagerEventHandler OnMoneyUpdated;
    public event GameManagerEventHandler OnScoreUpdated;
    public event GameManagerEventHandler OnLose;
    public event GameManagerEventHandler OnOrderGenerated;

    [FMODUnity.EventRef]
    public string angryEvent;
    [FMODUnity.EventRef]
    public string happyEvent;
    [FMODUnity.EventRef]
    public string mediumClient;
    [FMODUnity.EventRef]
    public string newOrderEvent;

    public int commandeNotReceived = 0;
   
    public int objectTrash = 0;

    float time = 0;

    public List<int> state = new List<int>();

    [SerializeField]
    private float _money;
    private float _score;
    private float elapsedTime;
    private float elapsedTime2;

    private RepairableObject _newOrder;

    public RepairableObject NewOrder => _newOrder;

    public List<float> moneyToAdd = new List<float>();

    public float Money
    {
        get
        {
            return _money;
        }

        set
        {
            _money = value;

            if(HUD.Instance)
            HUD.Instance.Money = _money;
            OnMoneyUpdated?.Invoke(this);
        }
    }

    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if (HUD.Instance)
                HUD.Instance.Score = _score;
        }
    }

    public static GameManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    public List<int> State { get => state; set => state = value; }
    public List<float> MoneyToAdd { get => moneyToAdd; set => moneyToAdd = value; }

    private void Awake()
    {
        m_instance = this;
        if (HUD.Instance)
        {
            HUD.Instance.Money = Money;
            HUD.Instance.Score = Score;
        }

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (repairableObjects.Count == 0)
            return;

        elapsedTime += Time.deltaTime;
        elapsedTime2 += Time.deltaTime;

        if(elapsedTime2 >= timeBetweenMoneyLoss)
        {
            _money -= moneyLoss;
            elapsedTime2 = 0;
        }

        if (Money <= 0) OnLose?.Invoke(this);

        Score = time * 10 - (commandeNotReceived * 1000) +  (State[(int)global::State.FIXED] * 500) + (State[(int)global::State.REPAIR2] * 350) + (State[(int)global::State.REPAIR1] * 250) + (State[(int)global::State.BROKEN] * 250) + (State[(int)global::State.REPAIR0] * 250) + objectTrash * 200;

    }

    public void OnCientEnter()
    {
        if ((!EntryDesk[0].IsFull || !EntryDesk[1].IsFull))
        {
            FMODUnity.RuntimeManager.PlayOneShot(newOrderEvent, transform.position);
            int index = createOrder(Random.Range(0, repairableObjects.Count));
            EntryDesk[index].Instance_OnOrderGenerated(this);
        }
        else
            commandeNotReceived++;
    }

    public void OnCientReceptEnter()
    {
        if(ExitDesk.repairableObject)
        {
            GameManager.Instance.Money += GameManager.Instance.MoneyToAdd[(int)ExitDesk.repairableObject.state];
            Destroy(ExitDesk.repairableObject.gameObject);
        }

   
    }

    public void OnCientReceptExit()
    {
        if (ExitDesk.repairableObject)
        {
            if(ExitDesk.repairableObject.state == global::State.REPAIR0)
                FMODUnity.RuntimeManager.PlayOneShot(angryEvent, transform.position);
            if (ExitDesk.repairableObject.state == global::State.FIXED)
                FMODUnity.RuntimeManager.PlayOneShot(happyEvent, transform.position);
            if (ExitDesk.repairableObject.state != global::State.FIXED && ExitDesk.repairableObject.state != global::State.REPAIR0)
                FMODUnity.RuntimeManager.PlayOneShot(happyEvent, transform.position);

        }


    }


    private int createOrder(int objectIndex)
    {
        int index = EntryDesk[0].IsFull ? 1 : 0;
        Transform entryDesk = EntryDesk[0].IsFull ? EntryDesk[1].transform : EntryDesk[0].transform;
        _newOrder = Instantiate(repairableObjects[objectIndex], entryDesk);
        return index;
    }

}
