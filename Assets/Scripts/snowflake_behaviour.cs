using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Snowflake : MonoBehaviour
{
    [Header("Horizontal Drift")]
    [SerializeField] public float horizontal;

    private Rigidbody2D rb;
    private float targetX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Snowflake: Player not found!");
            Destroy(gameObject);
            return;
        }

        // 🎯 ONE-TIME PLAYER TARGET
        targetX = player.transform.position.x;

        Debug.Log(
            $"[Snowflake Spawn] SpawnX={transform.position.x}, TargetX={targetX}"
        );
    }

    void FixedUpdate()
    {
        float newX = Mathf.Lerp(
            rb.position.x,
            targetX,
            horizontal * Time.fixedDeltaTime
        );

        // Only X controlled — gravity handles Y
        rb.MovePosition(new Vector2(newX, rb.position.y));

        Debug.Log(
            $"[Snowflake] X={rb.position.x:F2}, VelY={rb.linearVelocity.y:F2}"
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            Destroy(gameObject);

        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddPoint();
            Destroy(gameObject);
        }
    }
}