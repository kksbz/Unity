using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bullet;
    public float bulletSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody>();
        bullet.velocity = transform.up * bulletSpeed;
    }

    void OnEnable()
    {
        Invoke("DisableSelf", 4f);
    }
    public void DisableSelf() => gameObject.SetActive(false);

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy == null || enemy == default)
            {
                return;
            }
            enemy.Die();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
