using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sword : MonoBehaviour
{
    private bool swinging;
    private Animator Anim;
    public int damage;
    private bool hit;
    public AudioSource au;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && swinging && !hit)
        {
            hit = true;
            print(collision.gameObject.name);
            collision.gameObject.GetComponent<HealthController>().Damage(damage);
        }
        else if (collision.gameObject.tag == "boss" && swinging && !hit)
        {
            au.Play();
            hit = true;
            print(collision.gameObject.name);
            collision.gameObject.GetComponent<HealthController>().Damage(damage);
        }
    }

    private void Update()
    {
        if (!swinging)
        {
            hit = false;
        }
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("swing"))
        {
            swinging = true;
        }
        else
        {
            swinging = false;
        }
    }
}
