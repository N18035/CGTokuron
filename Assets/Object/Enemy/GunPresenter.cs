using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class GunPresenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Fire().Forget();
    }

    private async UniTaskVoid Fire(){
        while(true){
            Debug.Log("fire");
            int rnd = Random.Range(0, 2);
            if(rnd == 1) SEManager.I.Fire();
            
            await UniTask.Delay(2000);
        }
    }
}
