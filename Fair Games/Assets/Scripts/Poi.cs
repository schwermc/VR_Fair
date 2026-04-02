using UnityEngine;

public class Poi : MonoBehaviour
{
    public const string watertag = "Water";
    public PoiPaper poiPaper;

    [SerializeField] bool poiWaterCheck = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == watertag && !poiPaper.GetBroken())
        {
            poiWaterCheck = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == watertag && !poiPaper.GetBroken())
        {
            poiPaper.WaterLogPoi(Time.deltaTime);
        }
        if (poiPaper.GetBroken())
        {
            poiWaterCheck = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (poiWaterCheck)
        {
            poiPaper.UsePoi(1);
            poiWaterCheck = false;
        }
    }

    public void DestroyPoi()
    {
        Destroy(gameObject);
    }
}
