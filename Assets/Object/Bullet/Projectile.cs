using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class Projectile : MonoBehaviour
{
    // 消える秒数
    [SerializeField] Vector2 velo = Vector2.zero;

    [SerializeField] Rigidbody2D rBody; // リジッドボディを使うための宣言

    private IObjectPool<GameObject> objectPool;
    
    // ObjectPool への参照を与える public プロパティ。
    public IObjectPool<GameObject> ObjectPool { set => objectPool = value; }

    public void Go(){
        velo = new Vector2(0, 1);
    }

    void FixedUpdate()
    {
        rBody.velocity = velo;
    }
}