using UnityEngine;

public class Poi : MonoBehaviour
{
    public const string watertag = "Water";
    public PoiPaper poiPaper;

    void Start()
    {

    }

    void Update()
    {
        // Check if bool is true and then 'damage' poi
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == watertag)
        {
            // Bool equels true & make bool fasle when collision exit or when poi brakes
        }
    }
}
