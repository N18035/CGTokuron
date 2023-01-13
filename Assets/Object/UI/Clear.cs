using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

public class Clear : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] GameObject gg;
    void Start()
    {
        GameManager.I.State
        .Where(s => s == true)
        .Subscribe(_ =>  hoge())
        .AddTo(this);

    }

    void hoge(){
        gg.SetActive(true);
        texto.text = ScoreManager.I.Score.ToString();

    }

}
