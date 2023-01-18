using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float playerSpeed = 8.0f;
    public BulletManager bulletManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * playerSpeed;
        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);
        playerRb.velocity = newVelocity;
        ShootBullet();
    }
    
    void ShootBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = bulletManager.GetBullet();
            bullet.gameObject.transform.position = playerRb.position;
            bullet.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            bullet.SetActive(true);
        }
    }
    //죽었을때
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
