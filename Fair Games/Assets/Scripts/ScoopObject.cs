using UnityEngine;
using UnityEngine.Events;

public class ScoopObject : MonoBehaviour, IEventContainer
{
    [SerializeField]
    private UnityEvent destroyScooped;
    public UnityEvent _event { get { return destroyScooped; } }

    [SerializeField] Currency currency;
    [SerializeField] bool touched = false;
    [SerializeField] float timeTouched;
    [SerializeField] float timeAlive;

    [Header("Code Info")]
    [SerializeField] float minTT = 2f;
    [SerializeField] float maxTT = 4f;

    private int ticketAmount;

    void Awake()
    {
        if (maxTT <= minTT)
        {
            maxTT = minTT + 2;
        }
        timeAlive = Random.Range(100, 300);
        timeTouched = Random.Range(minTT, maxTT);
        ticketAmount = Mathf.RoundToInt(timeAlive) % 10;
    }

    void Update()
    {
        timeAlive -= Time.deltaTime;

        if (timeAlive <= 0)
        {
            DestroyFish();
        }

        if (touched)
        {
            timeTouched -= Time.deltaTime;
        }

        if (timeTouched <= 0 && timeAlive > 0)
        {
            currency.addToCurrency(ticketAmount);
            DestroyFish();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Poi Paper")
        {
            touched = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Poi Paper")
        {
            touched = false;
        }
    }

    void DestroyFish()
    {
        _event.Invoke();
        Destroy(transform.root.gameObject);
    }
}
