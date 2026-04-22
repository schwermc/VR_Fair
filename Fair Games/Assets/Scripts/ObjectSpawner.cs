using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform spawner;
    [SerializeField] float increaseHeight = 1f;
    [SerializeField] float widthPadding = 2f;
    [SerializeField] float spawnPadding = 2f;

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
        return spawner.transform.position + new Vector3(Random.Range(-x + (x/spawnPadding), x - (x/spawnPadding)), Random.Range(-y + (y/spawnPadding), y - (y/spawnPadding)), Random.Range(-z + (z/widthPadding), z - (z/widthPadding)));
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
