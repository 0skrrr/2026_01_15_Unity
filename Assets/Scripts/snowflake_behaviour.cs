using UnityEngine;

public class Snowflake : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddPoint();
            Destroy(gameObject);
        }
    }
}