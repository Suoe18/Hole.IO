using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSoundEffectScript : MonoBehaviour
{
    AudioSource holeSoundEffectAudioSource; 



    void Start()
    {
        holeSoundEffectAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PointObject")
        {
            holeSoundEffectAudioSource.Play();
        }
    }
}
