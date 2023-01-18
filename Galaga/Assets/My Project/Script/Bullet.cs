using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bullet;
    private bool isDead;
    public bool GetIsDead() {return isDead;}
    public float bulletSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody>();
        bullet.velocity = transform.forward * bulletSpeed;
        isDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
