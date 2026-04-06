using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] Currency tickets;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject canvas;

    void Update()
    {
        text.text = tickets.getCurrentCurrencyAmount().ToString();
    }

    void LateUpdate()
    {
        canvas.transform.LookAt(Camera.main.transform.position);
        canvas.transform.Rotate(0, 180, 0);
    }
}
