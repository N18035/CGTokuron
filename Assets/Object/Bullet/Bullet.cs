using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    public void GetDamage();
}

public class Bullet : MonoBehaviour,IDamage
{
    [SerializeField] BoxCollider2D col;

    public void GetDamage(){
        BGMManager.I.Pich();
    }

}
