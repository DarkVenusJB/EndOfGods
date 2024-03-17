using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Params")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform cannonPlatform;
    [SerializeField] private float shootingRadius;
    [Space]
    [Space]
    [Header("Bullet Params")]
    [SerializeField] private float coolDown;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    
    private ShootingCannon cannon;
    private Transform target;   

    private int hp;

    private void Start()
    {
        cannon = GetComponentInChildren<ShootingCannon>();
    }

    private void Update()
    {
        if(target!=null)
        {
            if(CheckDistance() <= shootingRadius)
            {
                cannonPlatform.LookAt(target.position);
                cannon.Shoot(bulletDamage, bulletSpeed, coolDown, target);
            }

            else
                target=null;           
        }

        else 
            CheckEnemy();      
    }

    private void CheckEnemy()
    {
        Collider[] enemy = Physics.OverlapSphere(transform.position, shootingRadius,enemyLayer);

        for(int i = 0; i < enemy.Length; i++)
        {
            bool isEnemy = enemy[i].TryGetComponent<EnemyDamager>(out var enemyController);

            if(isEnemy)
            {
                target = enemy[i].GetComponent<Transform>();
                break;
            }            
        }
    }

    private float CheckDistance()
    {
        float distance = Vector3.Distance(transform.position,target.position);
        return distance;
    }
}
