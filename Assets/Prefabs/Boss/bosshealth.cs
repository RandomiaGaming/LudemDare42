using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosshealth : MonoBehaviour
{
    public int Health;
    public int HeartContainers;
    public Image[] Hearts;
    public Sprite full;
    public Sprite Half;
    public Sprite Zero;
    public GameObject Bosshead;

    

    // Update is called once per frame
    void Update()
    {
        //Bosshead = GameObject.FindGameObjectWithTag("boss");
        if (Bosshead == null)
        {

            print("its");
        }else
        {
            print("yart");
            Health = Bosshead.GetComponent<HealthController>().GetHealth();
            
            if (Health <= 0)
            {
                Die();
            }
            if (Health > HeartContainers)
            {
                Health = HeartContainers;
            }
            for (int i = 0; i < Hearts.Length; i++)
            {

                if (i < Health / 2)
                {
                    Hearts[i].sprite = full;
                }
                else
                {
                    if (i < (Health + 1) / 2)
                    {
                        Hearts[i].sprite = Half;
                    }
                    else
                    {
                        Hearts[i].sprite = Zero;
                    }

                }

                
                    Hearts[i].gameObject.SetActive(true);
                
            }
        
        
        }



    }
    public void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(2);
    }
}
