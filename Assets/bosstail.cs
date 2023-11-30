using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstail : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("boss").GetComponent<bossHead>().timer < 0)
        {
            GameObject.FindGameObjectWithTag("boss").GetComponent<bossHead>().timer = 50;
            //collision.gameObject.GetComponent<player>().uuh.Play();
            collision.gameObject.GetComponent<HealthController>().Damage(1);
        }
    }

}
