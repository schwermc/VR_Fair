using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Vector3 vector;

    [SerializeField] Transform fishTrans;
    [SerializeField] float distance1;
    [SerializeField] float distance2;
    [SerializeField] float distance3;
    [SerializeField] float speed;
    [SerializeField] float rDist = 1f;
    [SerializeField] float rSpeed = 2.5f;

    private float movementX;
    private float movementY;
    private float movementZ;

    void Start()
    {
        if (fishTrans == null)
        {
            fishTrans = gameObject.transform;
        }
        vector = fishTrans.localPosition;
        distance1 = Random.Range(0.2f, rDist);
        distance2 = Random.Range(0f, rDist);
        distance3 = Random.Range(0f, rDist);
        speed = Random.Range(0.1f, rSpeed);
    }

    void Update()
    {
        movementX = Mathf.PingPong(Time.time * speed, distance1);
        movementY = Mathf.PingPong(Time.time * speed, distance2);
        movementZ = Mathf.PingPong(Time.time * speed, distance3);
        transform.position = vector + new Vector3(movementX, movementY, movementZ);
    }
}