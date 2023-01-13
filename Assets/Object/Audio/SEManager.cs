using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SEManager : Singleton<SEManager>
{
    AudioSource _audioSource;


    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    //うちわけ1:f、2:ge
    public List<AudioClip> SE = new List<AudioClip>(5);

    public void Fire(){
        _audioSource.volume = .7f;
        _audioSource.PlayOneShot(SE[0]);
    } 

    public void GetEnergy(){
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[1]);
    } 
}