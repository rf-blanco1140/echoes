using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource Test;
    void Start()
    {
        Test.Play(0);
        Debug.Log("test audio is playing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
