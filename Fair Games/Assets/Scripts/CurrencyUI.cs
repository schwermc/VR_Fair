using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] Currency tickets;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject canvas;

    private int tempAmount;

    void Start()
    {
        tempAmount = tickets.getCurrentCurrencyAmount();
    }

    void Update()
    {
        text.text = tickets.getCurrentCurrencyAmount().ToString();
    }

    void LateUpdate()
    {
        canvas.transform.LookAt(Camera.main.transform.position);
        canvas.transform.Rotate(0, 180, 0);
    }

    void OnApplicationQuit()
    {
        if (tickets.getCurrentCurrencyAmount() > tempAmount)
        {
            tickets.removeFromCurrency(tickets.getCurrentCurrencyAmount() - tempAmount);
        }

        if (tickets.getCurrentCurrencyAmount() < tempAmount)
        {
            tickets.addToCurrency(tempAmount - tickets.getCurrentCurrencyAmount());
        }
    }
}
