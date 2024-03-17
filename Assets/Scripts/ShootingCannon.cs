using UnityEngine;
using System.Collections;

public class ShootingCannon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPref;
       
    private bool canShoot = true;
    private Transform bulletSpawnPoint;
    private Vector3 bulletSpawnPos = Vector3.zero;
    

    private void Start()
    {
        bulletSpawnPoint =GetComponentInChildren<Transform>();
        bulletSpawnPos = bulletSpawnPoint.position;
    }

    public void Shoot(int damage, float speed, float timeToReload, Transform target = null)
    {
        if(canShoot)
        {
            Debug.Log("Shoot is Done");
            Bullet bullet = Instantiate(bulletPref, bulletSpawnPos, transform.rotation);
            bullet.SetBulletParam(damage, speed, target);     
            StartCoroutine(ShootReload(timeToReload));
        }                     
    }

    private IEnumerator ShootReload(float time)
    {
        canShoot = false;

        yield return new WaitForSeconds(time);

        canShoot = true;
    }
}
