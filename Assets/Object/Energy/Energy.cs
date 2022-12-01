using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnergy
{
    public void GetEnergy();
}

public class Energy : MonoBehaviour,IEnergy
{
    public void GetEnergy(){
        Destroy(gameObject);
    }
}

