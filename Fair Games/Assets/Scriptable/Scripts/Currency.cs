using UnityEngine;

[CreateAssetMenu(fileName = "Unnamed Currency", menuName = "Game Data/New Curreny")]
public class Currency : ScriptableObject
{
    [Min(0)]
    [SerializeField] int currentAmount = 0;
    [SerializeField] int maxAmount = 1000000000;

    public int getCurrentCurrencyAmount()
    {
        return currentAmount;
    }

    public int getMaxCurrencyAmount()
    {
        return maxAmount;
    }

    public void addToCurrency(int amount)
    {
        if (currentAmount < maxAmount)
        {
            currentAmount += amount;
            CheckCurrency();
        }
    }

    public void removeFromCurrency(int amount)
    {
        if (currentAmount > 0)
        {
            currentAmount -= amount;
            CheckCurrency();
        }
    }

    void CheckCurrency()
    {
        if (currentAmount > maxAmount)
        {
            currentAmount = maxAmount;
            return;
        }
        if (currentAmount < 0)
        {
            currentAmount = 0;
            return;
        }
    }
}
