using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }

    //Array of Sounds
    public Sounds[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        //When loading this object, don't destroy this game object from the previous game scene;
        DontDestroyOnLoad(gameObject);

        //For each sounds in the array, make sure to add this Component;
        foreach (Sounds s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Play the theme song of the game
        Play("ThemeSong");

    }

    public void Play(string name){

        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Unfortunately there's no song under this name at the moment..");
        }
        else {
            //Play Theme Song;
            s.source.Play();
        }

       }
          
}
