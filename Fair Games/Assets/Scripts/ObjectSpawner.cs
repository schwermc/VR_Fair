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

    void Update()
    {
        
    }

    Vector3 SpawnAtRandomPosition()
    {
        return spawner.transform.position + new Vector3(Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2), Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2), Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2));
    }

    void SpawnObject()
    {
        Instantiate(prefab, SpawnAtRandomPosition(), Quaternion.identity);
    }
}
