using UnityEngine;

public class SnowflakeSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject snowflakePrefab;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    [Header("Spawn Settings")]
    public float spawnInterval = 0.5f;

    void Start()
    {
        if (snowflakePrefab == null)
        {
            Debug.LogError("SnowflakeSpawner: Snowflake prefab is NOT assigned!");
            enabled = false;
            return;
        }

        InvokeRepeating(nameof(SpawnSnowflake), 0f, spawnInterval);
    }

    void SpawnSnowflake()
    {
        float randomX = Random.Range(
            leftPoint.position.x,
            rightPoint.position.x
        );

        Vector2 spawnPosition = new Vector2(
            randomX,
            5f
        );

        Instantiate(snowflakePrefab, spawnPosition, Quaternion.identity);
    }

    void OnDestroy()
    {
        CancelInvoke();
    }
}