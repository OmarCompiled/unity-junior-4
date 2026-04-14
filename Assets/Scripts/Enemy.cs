using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Rigidbody rigidbody;
    private float speedMultiplyer;
    private bool isGrounded = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        speedMultiplyer = Random.Range(6.0f, 10.0f);
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 direction = target.position - transform.position;
        direction /= speedMultiplyer * Time.fixedDeltaTime;
        if(isGrounded) 
        {
            rigidbody.AddForce(direction);
        }
    }

    void Update()
    {
        if(transform.position.y < -20)
        {
            Destroy(this.gameObject);
            GameManager.Instance.EnemyCount--;
            return;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
