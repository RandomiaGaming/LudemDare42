using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class collectable : MonoBehaviour
{
    public float speed;
    public int value;
    public int healthvalue;
    public AudioSource ding;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            /*//collision.GetComponent<player>().colect.Play();
            collision.gameObject.GetComponent<hearts>().Health += healthvalue;
            if ((collision.gameObject.GetComponent<hearts>().HeartContainers + value) <= 16)
            {
                collision.gameObject.GetComponent<hearts>().HeartContainers += value;
            }
            else
            {
                collision.gameObject.GetComponent<hearts>().HeartContainers = 16;
            }*/

            Destroy(gameObject);
        }
    }

    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

    }
}
