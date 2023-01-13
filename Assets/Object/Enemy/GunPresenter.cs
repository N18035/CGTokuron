using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Pool;

public class GunPresenter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzlePosition;
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
                GameObject bulletObject = m_objectPool.Get();
                if (bulletObject == null)    return;

                bulletObject.transform.position = muzzlePosition.position;
                bulletObject.GetComponent<Projectile>().Go();

                // プールから取得したオブジェクトを 10 秒後にプールに戻すコルーチン
                IEnumerator Process()
                {
                    yield return new WaitForSeconds( 10 );
                    bulletObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                    m_objectPool.Release(bulletObject);
                }

                StartCoroutine( Process() );
            } 

            await UniTask.Delay(3000);
        }
    }
}
