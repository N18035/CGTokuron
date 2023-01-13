using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public interface IEnergy
{
    public void GetEnergy();
}

public class Energy : MonoBehaviour,IEnergy
{
    [SerializeField]int time=500;
    [SerializeField] BoxCollider2D col;
    
    private void Start() {
        Updown().Forget();

        ReCalc();
    }

    public void GetEnergy(){
        ScoreManager.I.AddScore();
        SEManager.I.GetEnergy();
        MoveBack();
    }

    public void MoveBack(){
        Vector3 pos = this.gameObject.transform.position;
        pos.z = -15;
        col.enabled = false;
        this.gameObject.transform.position = pos; 
    }

    void ReCalc(){
        //最低2秒
        time = 500 * Random.Range(4, 6);
    }

    public void MoveForward(){
        Vector3 pos = this.gameObject.transform.position;
        pos.z = 0;
        col.enabled = true;
        this.gameObject.transform.position = pos; 
    }



    private async UniTaskVoid Updown(){
        while(true){
            MoveForward();
            await UniTask.Delay(time);
            MoveBack();
            await UniTask.Delay(time);
        }

    }
}

