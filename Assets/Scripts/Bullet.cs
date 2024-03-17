using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target = null;   
    private float _speed;
    private int _damge;

    private void Update()
    {
        MoveToTheTarget(_speed, _target);
        Destroy(this.gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isEnemy = other.gameObject.TryGetComponent<EnemyHealthSystem>(out var enemy);

        if (isEnemy)
            enemy.TakeDamage(_damge);
        
        Destroy(this.gameObject);
    }


    private void MoveToTheTarget(float speed, Transform target = null)
    {
        if (target != null)
        {
            Vector3 targetPosition = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
            transform.position = targetPosition;
        }

        else   
            transform.Translate(Vector3.forward * speed*Time.deltaTime);
    }

    public void SetBulletParam(int damage, float speed, Transform target = null)
    {
        _target = target;
        _speed = speed;
        _damge = damage;
    }
}
