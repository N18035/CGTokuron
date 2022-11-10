using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        Rigidbody rBody; // リジッドボディを使うための宣言

        //上0 左1 下2 右3
        public IReadOnlyReactiveProperty<int> Direction => _dire;
        private readonly ReactiveProperty<int> _dire = new ReactiveProperty<int>();
        void Start()
        {
            rBody = this.gameObject.GetComponent<Rigidbody>();

            InputManager.I.OnW
            .Subscribe(_ => Move(0))
            .AddTo(this);

            InputManager.I.OnA
            .Subscribe(_ => Move(1))
            .AddTo(this);

            InputManager.I.OnS
            .Subscribe(_ => Move(2))
            .AddTo(this);

            InputManager.I.OnD
            .Subscribe(_ => Move(3))
            .AddTo(this);
        }

        void Move(int n)
        {
            _dire.Value = n;
            // if (jumpNow == true) return;

            // rBody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            // jumpNow = true;
            
        }

    }
}

