using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class PlayerCore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            // this.gameObject.GetComponent<Collider>()
            // .OnTriggerEnterAsObservable()
            // .Throttle(TimeSpan.FromMilliseconds(10))
            // .Subscribe(x =>{
            //     if(x.gameObject.TryGetComponent<IEnergy>(out var energy)){
            //         energy.Get();

            //         //状態をゲット状態へ変更
            //         //動きを遅くする
            //         //発射可能
            //     }  
            // })
            // .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
