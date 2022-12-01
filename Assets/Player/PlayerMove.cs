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
        Rigidbody2D rBody; // リジッドボディを使うための宣言
        Vector2 velo = Vector2.zero;
        float speed=3;

        //上0 左1 下2 右3
        public IReadOnlyReactiveProperty<PlayerLookDirection> Direction => _dire;
        private readonly ReactiveProperty<PlayerLookDirection> _dire = new ReactiveProperty<PlayerLookDirection>();

        void Start()
        {
            rBody = this.gameObject.GetComponent<Rigidbody2D>();

            InputManager.I.OnW
            .Subscribe(_ => Move(0,1,PlayerLookDirection.Top))
            .AddTo(this);

            InputManager.I.OnA
            .Subscribe(_ => Move(-1,0,PlayerLookDirection.Left))
            .AddTo(this);

            InputManager.I.OnS
            .Subscribe(_ => Move(0,-1,PlayerLookDirection.Bottom))
            .AddTo(this);

            InputManager.I.OnD
            .Subscribe(_ => Move(1,0,PlayerLookDirection.Right))
            .AddTo(this);
        }

        void Move(int x,int y,PlayerLookDirection d)
        {
            _dire.Value = d;

            velo = new Vector2(x * speed, y * speed);
            
        }


        void FixedUpdate()
        {
            rBody.velocity = velo;
        }

        private void Update()
        {
            var pos = transform.position;

            // x軸方向の移動範囲制限
            pos.x = Mathf.Clamp(pos.x, -10, 10);
            pos.y = Mathf.Clamp(pos.y, -10, 10);

            transform.position = pos;
        }

    }
}

