using UnityEngine;

public class PoiPaper : MonoBehaviour
{
    [SerializeField] bool broken = false;
    [SerializeField] int usesLeft;
    [SerializeField] float stregth;
    [SerializeField] Material handleColor;

    private int randomUses;
    private int randomStregth;
    private Color color;

    void Awake()
    {
        randomUses = Random.Range(4, 34);
        randomStregth = Random.Range(100, 300);

        usesLeft = randomUses;
        stregth = randomStregth;
    }

    void Start()
    {
        BaseColor();
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.transform.root.CompareTag("Fish"))
        {
            handleColor.color = Color.white;
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.transform.root.CompareTag("Fish"))
        {
            BaseColor();
        }
    }

    public PoiPaper()
    {
        usesLeft = randomUses;
        stregth = randomStregth;
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
            BaseColor();
            gameObject.SetActive(false);
            return;
        }
    }

    public bool GetBroken() { return broken; }
    public (int, float) GetStatus() { return (usesLeft, stregth); }

    void BaseColor() { handleColor.color = color; }

    private void OnApplicationQuit()
    {
        BaseColor();
    }

    void OnDestroy()
    {
        BaseColor();
    }
}
