using UnityEngine;

public class Poi : MonoBehaviour
{
    public const string watertag = "Water";
    public PoiPaper poiPaper;

    [SerializeField] bool poiWaterCheck = false;

    void Start()
    {

    }

    void Update()
    {
        // Check if bool is true and then 'damage' poi
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == watertag && !poiPaper.GetBroken())
        {
            poiWaterCheck = true;
            Debug.Log("Poi in some water: " + poiWaterCheck);
            // Bool equels true & make bool fasle when collision exit or when poi brakes
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        poiWaterCheck = false;
        Debug.Log("Poi in some water: " + poiWaterCheck);
    }
}
