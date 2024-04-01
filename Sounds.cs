using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//To show it in the Inspector
[System.Serializable]
public class Sounds
{
    public AudioClip clip;
    //Creating a Slider..
    [Range(0f, 0.1f)]

    //In order to adjust the strength of the game volume;
    public float volume;
    [Range(.1f, 3.0f)]

    public float pitch;

    public string name;

    public bool loop;

    //Hiding in the Inspector section;
    [HideInInspector]
    public AudioSource source; 
    
}
