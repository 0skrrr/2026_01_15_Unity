using UnityEngine;

public class SnowflakeSpawner : MonoBehaviour
{
    public GameObject snowflakePrefab;
    public GameObject leftPoint;
    public GameObject rightPoint;

    public float spawnInterval = 0.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnSnowflake), 0f, spawnInterval);
    }

    void SpawnSnowflake()
    {
        float randomX = Random.Range(
            leftPoint.transform.position.x,
            rightPoint.transform.position.x
        );

        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        Instantiate(snowflakePrefab, spawnPosition, Quaternion.identity);
    }
}