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

        void ChangeModel(int d){
            renderer.sprite = playerImage[d];
        }
    }
}

