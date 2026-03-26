using UnityEngine;

public class PoiPaper : MonoBehaviour
{
    [SerializeField] bool broken = false;
    [SerializeField] int usesLeft;
    [SerializeField] float stregth;

    private int randomNumber;
    void Awake()
    {
        randomNumber = Random.Range(4, 34);
    }

    public PoiPaper()
    {
        usesLeft = randomNumber;
        stregth = 100f;
    }

    public PoiPaper(int usesLeft = 17, float stregth = 100f)
    {
        this.usesLeft = usesLeft;
        this.stregth = stregth;
    }

    public void UsePoi(int useAmount, float stregthAmount = 0)
    {
        usesLeft -= useAmount;
        stregth -= stregthAmount;
        CheckUsesLeft();
    }

    #region Poi In Water
    public void WaterLogPoi(float timeInWater)
    {
        stregth -= timeInWater;
        CheckUsesLeft();
    }

    public void WaterLogPoi(float stregthAmount, int useAmount = 0)
    {
        usesLeft -= useAmount;
        stregth -= stregthAmount;
        CheckUsesLeft();
    }
    #endregion

    public void CheckUsesLeft()
    {
        if (usesLeft <= 0 || stregth <= 0)
        {
            Debug.Log("Poi broke");
            broken = true;
            gameObject.SetActive(false);
            return;
        }
    }

    public bool GetBroken() { return broken; }
    public (int, float) GetStatus() { return (usesLeft, stregth); }

    public int NewRandomNumber() { return Random.Range(4, 34); }
}
