using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour,IEnergy
{
    public void GetEnergy(){

    }
}

public interface IEnergy
{
    public void GetEnergy();
}