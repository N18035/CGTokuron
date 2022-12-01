using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DesignPatterns.ObjectPool
{
    // projectile revised to use UnityEngine.Pool in Unity 2021
    public class Projectile : MonoBehaviour
    {
        // 消える秒数
        [SerializeField] private float timeoutDelay = 3f;

        private IObjectPool<Projectile> objectPool;

        // ObjectPool への参照を Projectile に与える public プロパティ。
        public IObjectPool<Projectile> ObjectPool { set => objectPool = value; }

        public void Deactivate()
        {
            StartCoroutine(DeactivateRoutine(timeoutDelay));
        }

        IEnumerator DeactivateRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);

            // 動きを止める
            Rigidbody2D rBody = GetComponent<Rigidbody2D>();
            rBody.velocity = new Vector2(0f, 0f);
            //角度はいらん
            // rBody.angularVelocity = new Vector2(0f, 0f);

            // release the projectile back to the pool
            objectPool.Release(this);
        }
    }
}
