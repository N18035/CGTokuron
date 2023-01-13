using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class TimeView : MonoBehaviour
{
   	[SerializeField] private TextMeshProUGUI texto;

    public void Set(int s){
        texto.text = s.ToString();
    }
}
