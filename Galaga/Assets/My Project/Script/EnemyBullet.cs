using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody bullet;
    public float bulletSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        bullet = gameObject.GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        Debug.Log("탄삭제 실행중");
        Invoke("DisableSelf", 4f);
    }
    public void DisableSelf() => gameObject.SetActive(false);

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player == null || player == default)
            {
                return;
            }
            player.Die();
        }
    }
    public void SetVelocity()
    {
        bullet.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    
