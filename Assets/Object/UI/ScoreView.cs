using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class ScoreView : MonoBehaviour
{
   	// private TextMeshProUGUI text;
    [SerializeField] ScoreManager manager;
 
    void Start()
    {
		// textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        // ScoreManager.I.Score
        // .Subscribe(s => text.SetText("r"))
        // .AddTo(this);
    }
}
