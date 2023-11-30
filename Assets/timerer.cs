using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timerer : MonoBehaviour {
    public float timer;
    public GameObject boss;
    public Text time;
    public GameObject[] unload;
    private bool loaded;
	void Update () {
        
        time.text = Mathf.RoundToInt(timer).ToString() + " Seconds.";
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (!loaded)
            {
                Instantiate(boss);
                foreach (GameObject go in unload)
                {
                    go.SetActive(false);
                }
                loaded = true;
            }
            Destroy(gameObject);
        }
	}
}
