using UnityEngine;

public class DestroyPoi : MonoBehaviour
{
    [SerializeField] Currency currency;
    [SerializeField] int increaseTickets = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Poi"))
        {
            currency.addToCurrency(increaseTickets);
            Destroy(other.gameObject.transform.root.gameObject);
        }
    }
}
