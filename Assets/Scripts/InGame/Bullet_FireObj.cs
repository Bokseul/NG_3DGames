using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_FireObj : MonoBehaviour
{
    private Vector3 mDirection;
    public GameObject fx_obj;
    public GameObject explosionFire;

    public void Shoot(Vector3 direction)
    {
        this.mDirection = direction * Time.deltaTime;
        //transform.LookAt(direction);
        fx_obj = Instantiate(explosionFire, transform.position, transform.rotation);
        Invoke("DestroyBullet", 5f);
    }

    public void DestroyBullet()
    {
        ObjectPoolIG.sReturnFireObject(this);
        Destroy(fx_obj);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(fx_obj);
        }
    }

}
