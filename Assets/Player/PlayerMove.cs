using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerMove : MonoBehaviour
    {
        Rigidbody rBody; // リジッドボディを使うための宣言

        // Start is called before the first frame update
        void Start()
        {
            rBody = this.gameObject.GetComponent<Rigidbody>();

            InputManager.I.OnW
                .Subscribe(_ => Move())
                .AddTo(this);
        }

        void Move()
        {
            if (jumpNow == true) return;

            rBody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            jumpNow = true;
            
        }

    }
}

