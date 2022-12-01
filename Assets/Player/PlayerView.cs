using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] PlayerMove move;
        [SerializeField] SpriteRenderer renderer;
        [SerializeField] List<Sprite> playerImage;

        private void Start() {
            move.Direction
            .Subscribe(d => ChangeModel(d))
            .AddTo(this);
        }

        void ChangeModel(PlayerLookDirection d){
            renderer.sprite = playerImage[(int)d];
        }
    }


    public enum PlayerLookDirection
    {
        Top = 0,
        Bottom = 1,
        Left = 2,
        Right = 3
    }
}

