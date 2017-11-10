using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public AudioSource playSound;
    public AudioSource backgroundMusic;
    public static SoundManager instance = null;


	// Use this for initialization
	void Start () {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

	}
	

    public void playMusic(AudioClip clip)
    {
        playSound.clip = clip;
        playSound.Play();
    }
}
