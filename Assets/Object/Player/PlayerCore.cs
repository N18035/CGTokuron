using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] BoxCollider2D co;
    // Start is called before the first frame update
    void Start()
    {
        co = this.gameObject.GetComponent<BoxCollider2D>();

        co.OnTriggerEnter2DAsObservable()
        .Throttle(TimeSpan.FromMilliseconds(10))
        .Subscribe(x =>{
            if(x.gameObject.TryGetComponent<IEnergy>(out var energy)){
                energy.GetEnergy();
                //動きを遅くする
            }  
        })
        .AddTo(this);


        co.OnTriggerEnter2DAsObservable()
        .Throttle(TimeSpan.FromMilliseconds(10))
        .Subscribe(x =>{
            if(x.gameObject.TryGetComponent<IDamage>(out var damage)){
                damage.GetDamage();
                ShakeCamera.I.Shake(0.25f, 0.2f);
                //無敵
            }  
        })
        .AddTo(this);
    }
}
