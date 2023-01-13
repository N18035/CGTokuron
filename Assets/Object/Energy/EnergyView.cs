using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class EnergyView : MonoBehaviour
{
    [SerializeField]Sprite img1;
    [SerializeField]Sprite img2;
    [SerializeField] SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Updown().Forget();
    }

    private async UniTaskVoid Updown(){
        while(true){
            renderer.sprite = img1;
            await UniTask.Delay(500);
            renderer.sprite = img2;
            await UniTask.Delay(500);
        }
    }
}
