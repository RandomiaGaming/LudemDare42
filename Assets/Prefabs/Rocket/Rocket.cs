using UnityEngine;
public class Rocket : MonoBehaviour
{
    public float flyForce;
    private new Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigidbody2D.velocity = new Vector2(flyForce, 0);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthController>().Damage(1);
        }
    }
}
