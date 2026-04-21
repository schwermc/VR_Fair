using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform spawner;

    private Vector3 spawnerSize;

    void Awake()
    {
        spawnerSize = spawner.transform.localScale;
    }

    void Start()
    {
        SpawnObject();
        SpawnObject();
        SpawnObject();
        SpawnObject();
    }

    Vector3 SpawnAtRandomPosition()
    {
        float x = spawnerSize.x / 2;
        float y = spawnerSize.y / 2;
        float z = spawnerSize.z / 2;

        return spawner.transform.position + new Vector3(Random.Range(-x + (x/4), x - (x/4)), Random.Range(-y + (y/4), y - (y/4)), Random.Range(-z + (z/4), z - (z/4))); 
    }

    public void SpawnObject()
    {
        Instantiate(prefab, SpawnAtRandomPosition(), Quaternion.identity);
    }
}
