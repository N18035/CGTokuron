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

                //状態をゲット状態へ変更
                //動きを遅くする
                //発射可能
            }  
        })
        .AddTo(this);
    }
}
