using UnityEngine;
public class ParatrooperAttackBox : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthController>().Damage(1);
        }
    }
}
