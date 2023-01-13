using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Pool;

public class GunPresenter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private float muzzleVelocity = 700f;
    private ObjectPool<GameObject> m_objectPool; // オブジェクトプール
    void Start()
    {
        // オブジェクトプールを作成します
        m_objectPool = new ObjectPool<GameObject>
        (
            createFunc: CreateProjectile,         // プールにオブジェクトが不足している時にオブジェクトを生成するために呼び出されます
            actionOnGet: OnTakeFromPool,          // プールからオブジェクトを取得する時に呼び出されます
            actionOnRelease: OnReturnedToPool,    // プールにオブジェクトを戻す時に呼び出されます
            actionOnDestroy: OnDestroyPoolObject, // プールの最大サイズを超えたオブジェクトを削除する時に呼び出されます
            collectionCheck: true,                // すでにプールに戻されているオブジェクトをプールに戻そうとした時にエラーを出すなら true
            defaultCapacity: 10,                  // 内部でプールを管理する Stack のデフォルトのキャパシティ
            maxSize: 10                           // プールするオブジェクトの最大数。最大数を超えたオブジェクトに対しては actionOnRelease ではなく actionOnDestroy が呼ばれます
        );

        Fire().Forget();
    }

    // プールにオブジェクトが不足している時にオブジェクトを生成するために呼び出されます
    private GameObject CreateProjectile()
    {
        // GameObject projectileInstance = Instantiate(projectilePrefab);
        // projectileInstance.ObjectPool = m_objectPool;
        // return projectileInstance;

        return Instantiate(projectilePrefab);
    }

    // プールからオブジェクトを取得する時に呼び出されます
    private void OnTakeFromPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    // プールにオブジェクトを戻す時に呼び出されます
    private void OnReturnedToPool(GameObject pooledObject)
    {
        // プールに戻すオブジェクトは非アクティブにします
        pooledObject.gameObject.SetActive(false);
    }

    // プールの最大サイズを超えたオブジェクトを削除する時に呼び出されます
    private void OnDestroyPoolObject(GameObject pooledObject)
    {
        // 最大サイズを超えたオブジェクトはプールに戻さずに削除します
        Destroy(pooledObject.gameObject);
    }

    private async UniTaskVoid Fire(){
        while(true){
            int rnd = Random.Range(0, 2);
            if(rnd == 1){
                // Debug.Log("fire");
                // SEManager.I.Fire();
                GameObject bulletObject = m_objectPool.Get();
                if (bulletObject == null)    return;

                // align to gun barrel/muzzle position
                bulletObject.transform.position = muzzlePosition.position;
                // move projectile forward
                // bulletObject.GetComponent<Rigidbody2D>().AddForce(bulletObject.transform.forward);
                bulletObject.GetComponent<Projectile>().hoge();


                // プールから取得したオブジェクトを 2 秒後にプールに戻すコルーチン
                IEnumerator Process()
                {
                    yield return new WaitForSeconds( 10 );
                    bulletObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                    m_objectPool.Release(bulletObject);
                }

                // プールから取得したオブジェクトを 2 秒後にプールに戻すコルーチンを実行します
                StartCoroutine( Process() );
            } 

            
            await UniTask.Delay(3000);
        }
    }
}
