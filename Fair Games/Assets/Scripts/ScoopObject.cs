using UnityEngine;

public class ScoopObject : MonoBehaviour
{
    [SerializeField] Currency currency;
    [SerializeField] bool touched = false;
    [SerializeField] float timeTouched;
    [SerializeField] float timeAlive;

    private int ticketAmount;

    void Awake()
    {
        timeAlive = Random.Range(100, 300);
        timeTouched = Random.Range(7, 15);
        ticketAmount = Mathf.RoundToInt(timeTouched) / 3;
    }

    void Update()
    {
        timeAlive -= Time.deltaTime;

        if (timeAlive <= 0)
        {
            Destroy(transform.root.gameObject);
        }

        if (touched)
        {
            timeTouched -= Time.deltaTime;
        }

        if (timeTouched <= 0 && timeAlive > 0)
        {
            currency.addToCurrency(ticketAmount);
            Destroy(transform.root.gameObject);
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
}
