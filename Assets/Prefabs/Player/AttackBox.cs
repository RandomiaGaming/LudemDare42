using UnityEngine;
public class AttackBox : MonoBehaviour
{
    public int damage = 1;
    public bool active = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!active)
        {
            return;
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<HealthController>().Damage(damage);
        }
    }
}
