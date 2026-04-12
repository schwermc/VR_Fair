using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Vector3 vector;

    [SerializeField] Transform fishTrans;

    void Start()
    {
        if (fishTrans == null)
        {
            fishTrans = gameObject.transform;
        }
        vector = fishTrans.localPosition;
    }
}
