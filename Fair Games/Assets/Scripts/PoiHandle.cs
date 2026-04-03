using UnityEngine;

public class PoiHandle : MonoBehaviour
{
    public Poi poi;

    [SerializeField] float timer = 300f;
    [SerializeField] bool OnGround = false;

    private void Update()
    {
        if (poi.poiPaper.GetBroken() || OnGround)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            poi.DestroyPoi();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
}
