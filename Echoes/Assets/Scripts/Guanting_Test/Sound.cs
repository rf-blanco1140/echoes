using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    public string name;

    public AudioClip clip;

    public float volume;
    public float pitch;
    public bool spatialize;
    [Range(0, 1)] public float spatialBlend;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

