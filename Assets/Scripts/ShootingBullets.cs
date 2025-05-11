using System.Collections;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float shootForce;
    private bool canShoot = true;

    public void ShootBullet()
    {
        var bulletClone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        var bulletRigidBody = bulletClone.GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(transform.forward * shootForce);
    }
    void Update()
    {
        if(GameManager.Instance.gamepaused) return;
        if (Input.GetKey(KeyCode.Mouse0) && canShoot )
        {
            StartCoroutine(TimerOfDelay());
            ShootBullet();
        }
    }
    private IEnumerator TimerOfDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
