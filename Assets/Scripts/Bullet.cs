﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mDirection;
    private int speed = 1;
    public GameObject explosion;
    public GameObject fx_obj;

    public void Shoot(Vector3 direction)
    {
        //transform.LookAt(direction);
        this.mDirection = direction * speed * Time.deltaTime;
        fx_obj = Instantiate(explosion, transform.position, transform.rotation);
        Invoke("DestroyBullet", 5f);
        
    }


    public void DestroyBullet()
    {
        ObjectPoolIG.sReturnObject(this);
        Destroy(fx_obj);
    }


    void Update()
    {
        //transform.Translate(mDirection);
        transform.Translate(Vector3.forward);
    }

    
}