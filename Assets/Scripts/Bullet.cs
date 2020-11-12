using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mDirection;

    public void Shoot(Vector3 direction)
    {
        this.mDirection = direction;
        Destroy(gameObject, 7f);
    }
    
    void Update()
    {
        transform.Translate(mDirection);
    }
}
