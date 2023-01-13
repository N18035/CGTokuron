using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    [SerializeField] AudioSource audioSource;

    public void Pich(){
        // audioSource.pitch += 0.2f;
        // audioSource.pitch = 15f;
    }
}
