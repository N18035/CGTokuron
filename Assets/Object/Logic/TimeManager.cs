using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TimeManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] TimeView view;
    private readonly ReactiveProperty<int> _lastTime = new ReactiveProperty<int>();

    void Start(){
        _lastTime.Value = (int)_audioSource.clip.length -1;
    }

    void Update(){
        _lastTime.Value = (int)_audioSource.clip.length - (int)_audioSource.time;
        view.Set(_lastTime.Value);
    }
}
