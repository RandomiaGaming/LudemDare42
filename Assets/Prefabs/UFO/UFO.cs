using UnityEngine;

public class UFO : MonoBehaviour
{
    public float bounceForce;
    public float moveSpeed;

    private float floorPositionY;
    private new Rigidbody2D rigidbody2D;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        floorPositionY = transform.position.y;
    }
    void Update()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
        if (transform.position.y < floorPositionY)
        {
            transform.position = new Vector3(transform.position.x, floorPositionY, transform.position.z);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, bounceForce);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthController>().Damage(1);
        }
    }
}