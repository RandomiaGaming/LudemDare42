using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class audioer : MonoBehaviour {
    private AudioSource[] audios;
    public int time;
    private float currenttime;
    private System.Random rnd = new System.Random();
    private AudioSource current;
    // Use this for initialization
    void Start () {
        audios = GetComponents<AudioSource>();

        audios[rnd.Next(0, audios.Length)].Play();

	}
	
	// Update is called once per frame
	void Update () {
        currenttime += Time.deltaTime;
        if (currenttime > time)
        {
            currenttime = 0;
            foreach(AudioSource au in audios)
            {
                au.Stop();
            }
            audios[rnd.Next(0, audios.Length)].Play();

        }
	}
    
}
