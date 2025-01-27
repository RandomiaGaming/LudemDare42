using UnityEngine;
public class Paratrooper : MonoBehaviour
{
    public float gravityForce;

    private new Rigidbody2D rigidbody2D;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigidbody2D.velocity = new Vector2(0, gravityForce);
    }
    public void OnKilled()
    {
        Destroy(gameObject);
    }
}
