using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody = default;
    private float playerSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInPut = Input.GetAxis("Horizontal");
        float xSpeed = xInPut * playerSpeed;
        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);
        playerRigidbody.velocity = newVelocity;
    }

    public void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
