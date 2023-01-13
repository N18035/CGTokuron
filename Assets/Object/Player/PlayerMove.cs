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



            // InputManager.I.OnW
            // .Subscribe(_ => _dire.Value = PlayerLookDirection.Top)
            // .AddTo(this);

            // InputManager.I.OnA
            // .Subscribe(_ => _dire.Value = PlayerLookDirection.Left)
            // .AddTo(this);

            // InputManager.I.OnS
            // .Subscribe(_ => _dire.Value = PlayerLookDirection.Bottom)
            // .AddTo(this);

            // InputManager.I.OnD
            // .Subscribe(_ => _dire.Value = PlayerLookDirection.Right)
            // .AddTo(this);
        }

        void FixedUpdate()
        {
            rBody.velocity = velo;
        }

        private void Update()
        {
            var move = GetInputMove();

            if (move.x != 0)
            {
                velo = new Vector2(move.x * speed, 0);
                if (move.x > 0)    _dire.Value = PlayerLookDirection.Right;
                else                _dire.Value = PlayerLookDirection.Left;
            }
            else if (move.y != 0)
            {
                velo = new Vector2(0, move.y * speed);
                if (move.y > 0)    _dire.Value = PlayerLookDirection.Top;
                else                _dire.Value = PlayerLookDirection.Bottom;
            }
            else
            {
                velo = Vector2.zero;
            }


            //Clamp
            var pos = transform.position;
            // x軸方向の移動範囲制限
            pos.x = Mathf.Clamp(pos.x, -8, 8);
            pos.y = Mathf.Clamp(pos.y, -3.5f, 3.5f);

            transform.position = pos;
        }

        (float x, float y) GetInputMove()
        {
            return (
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
        }
    }
}

