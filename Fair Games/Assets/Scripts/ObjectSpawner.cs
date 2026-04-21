using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform spawner;
    [SerializeField] float increaseHeight = 1f;

    private Vector3 spawnerSize;
    private bool start = false;

    void Awake()
    {
        spawnerSize = spawner.transform.localScale;
    }

    void Start()
    {
        start = true;
        SpawnObject();
        SpawnObject();
        SpawnObject();
        SpawnObject();
        start = false;
    }

    Vector3 SpawnAtRandomPosition()
    {
        float x = spawnerSize.x / 2;
        float y = spawnerSize.y / 2;
        float z = spawnerSize.z / 2;

        //return spawner.transform.position + new Vector3(Random.Range(-x + (x/4), x - (x/4)), Random.Range(-y + (y/4), y - (y/4)), Random.Range(-z + (z/4), z - (z/4))); 
        return spawner.transform.position + new Vector3(Random.Range(-x + (x/2), x - (x/2)), Random.Range(-y + (y/2), y - (y/2)), Random.Range(-z + (z/2), z - (z/2)));
    }

    public void SpawnObject()
    {
        Vector3 vector = SpawnAtRandomPosition();
        if (!start)
        {
            vector.y += increaseHeight;
        }

        Instantiate(prefab, vector, Quaternion.identity);
    }
}
