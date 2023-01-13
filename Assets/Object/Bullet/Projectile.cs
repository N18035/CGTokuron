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
    
    // ObjectPool への参照を Projectile に与える public プロパティ。
    public IObjectPool<GameObject> ObjectPool { set => objectPool = value; }

    public void hoge(){
        velo = new Vector2(0, 1);
    }

    void FixedUpdate()
    {
        rBody.velocity = velo;
    }

    // public void Deactivate()
    // {
    //     StartCoroutine(DeactivateRoutine(timeoutDelay));
    // }

    // IEnumerator DeactivateRoutine(float delay)
    // {
    //     yield return new WaitForSeconds(delay);

    //     // 動きを止める
    //     Rigidbody2D rBody = GetComponent<Rigidbody2D>();
    //     rBody.velocity = new Vector2(0f, 0f);
    //     //角度はいらん
    //     // rBody.angularVelocity = new Vector2(0f, 0f);

    //     // release the projectile back to the pool
    //     objectPool.Release(this.gameObject);
    // }
}