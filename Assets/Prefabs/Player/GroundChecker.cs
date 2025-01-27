using UnityEngine;
public class GroundChecker : MonoBehaviour
{
    [HideInInspector]
    public bool grounded = false;
    private void FixedUpdate()
    {
        grounded = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
