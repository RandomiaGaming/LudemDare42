using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHead : MonoBehaviour
{
    public float length;
    public float speed;
    private GameObject Player;
    public int timer;
    private int spawnrate;
    public int rate;
    public GameObject body;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && timer < 0)
        {
            timer = 50;
            //collision.gameObject.GetComponent<player>().uuh.Play();
            collision.gameObject.GetComponent<HealthController>().Damage(1);
        }
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        spawnrate--;
        if(spawnrate < 0)
        {
            spawnrate = rate;
            GameObject go = Instantiate(body, transform.position, transform.rotation);
            Destroy(go, length);
        }
        timer--;
    }
}
