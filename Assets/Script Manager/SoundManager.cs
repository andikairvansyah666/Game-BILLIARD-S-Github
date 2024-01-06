using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; set; }
    public AudioSource music; 
    public AudioSource soundEffect;
    public AudioClip soundButton;
    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuteSound()
    {
        if (music.mute == false)
        {
            music.mute = true;
        }
        else
        {
            music.mute = false;
        }
    }
    public void SoundButton()
    {
        soundEffect.PlayOneShot(soundButton);
    }
}
