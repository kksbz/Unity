using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody bullet;
    public float bulletSpeed = 8.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody>();
        bullet.velocity = -1 * transform.up * bulletSpeed;
    }

    void OnEnable()
    {
        Invoke("DisableSelf", 4f);
    }
    public void DisableSelf() => gameObject.SetActive(false);

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.Die();
        }
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
