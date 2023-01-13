using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class ScoreView : MonoBehaviour
{
   	[SerializeField]private TextMeshProUGUI texto;
 
    void Start()
    {
        ScoreManager.I.Score
        .Subscribe(s => texto.text = s.ToString())
        .AddTo(this);
    }
}
