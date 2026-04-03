using UnityEngine;

public class DestroyPoi : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Poi"))
        {
            Destroy(other.gameObject.transform.root.gameObject);
        }
    }
}
