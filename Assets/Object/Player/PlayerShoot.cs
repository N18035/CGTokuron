using UnityEngine;
using UnityEngine.Pool;
using UniRx;

namespace DesignPatterns.ObjectPool
{
    public class PlayerShoot : MonoBehaviour
    {
        [Tooltip("Prefab to shoot")]
        [SerializeField] private Projectile projectilePrefab;
        [Tooltip("Projectile force")]
        [SerializeField] private float muzzleVelocity = 700f;
        [Tooltip("End point of gun where shots appear")]
        [SerializeField] private Transform muzzlePosition;
        [Tooltip("Time between shots / smaller = higher rate of fire")]
        [SerializeField] private float cooldownWindow = 0.1f;

        // stack-based ObjectPool available with Unity 2021 and above
        private IObjectPool<Projectile> objectPool;

        // throw an exception if we try to return an existing item, already in the pool
        //すでにプールにある既存のアイテムを返そうとすると、例外が発生します。
        [SerializeField] private bool collectionCheck = true;

        // extra options to control the pool capacity and maximum size
        //プール容量と最大サイズをコントロールする追加オプション
        [SerializeField] private int defaultCapacity = 20;
        [SerializeField] private int maxSize = 1;

        private float nextTimeToShoot;

        //最初に生成
        private void Awake()
        {
            objectPool = new ObjectPool<Projectile>(CreateProjectile,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                collectionCheck, defaultCapacity, maxSize);
        }

        // invoked when creating an item to populate the object pool
        //オブジェクト生成処理
        private Projectile CreateProjectile()
        {
            Projectile projectileInstance = Instantiate(projectilePrefab);
            projectileInstance.ObjectPool = objectPool;
            return projectileInstance;
        }

        // invoked when returning an item to the object pool
        //プールに戻される時に実行する処理
        private void OnReleaseToPool(Projectile pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        // invoked when retrieving the next item from the object pool
        //オブジェクト取得時に実行する処理
        private void OnGetFromPool(Projectile pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }

        // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
        //maxSizeを超えたときの破棄処理
        private void OnDestroyPooledObject(Projectile pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }

        void Start(){
            InputManager.I.OnSpace
            //where(射撃状態)
            .Subscribe(_ => Shoot())
            .AddTo(this);
        }

        void Shoot(){

            // if (Input.GetdownButton("Fire1") && Time.time > nextTimeToShoot && objectPool != null)
            // // get a pooled object instead of instantiating
            //     RevisedProjectile bulletObject = objectPool.Get();

            //     if (bulletObject == null)
            //         return;

            //     // align to gun barrel/muzzle position
            //     bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            //     // move projectile forward
            //     bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);

            //     // turn off after a few seconds
            //     bulletObject.Deactivate();

            //     // set cooldown delay
            //     nextTimeToShoot = Time.time + cooldownWindow;
        }
    }
}
