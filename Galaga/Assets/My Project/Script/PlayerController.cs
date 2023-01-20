using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Material a;
    public Material b;
    private Material[] playerMt;
    public static int life;
    public float playerSpeed = 8.0f;
    public bool isRespawnTime;
    public BulletManager bulletManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerMt = new Material[2] { a, b };
        gameObject.GetComponent<MeshRenderer>().material = playerMt[0];
        life = 3;
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

    //리스폰 함수
    void RespawnTime()
    {
        isRespawnTime = !isRespawnTime;
        if (isRespawnTime)
        {
            gameObject.GetComponent<MeshRenderer>().material = playerMt[1];
            //Debug.Log("태그변경 리스폰");
            gameObject.tag = "ReSpwan";
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = playerMt[0];
            //Debug.Log("태그변경 플레이어");
            gameObject.tag = "Player";
        }
    }
    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        //목숨있으면 리스폰 무적3초상태
        RespawnTime();
        Invoke("RespawnTime", 3f);
        life -= 1;
        if (life == 2)
        {
            GameObject playerLifes = GFunc.GetRootObj("PlayerLife2");
            PlayerLife playerLife = playerLifes.GetComponent<PlayerLife>();
            playerLife.PlayerDie();
        }
        else if (life == 1)
        {
            GameObject playerLifes = GFunc.GetRootObj("PlayerLife1");
            PlayerLife playerLife = playerLifes.GetComponent<PlayerLife>();
            playerLife.PlayerDie();
        }

        if (life == 0)
        {
            gameObject.SetActive(false);
            GameObject gameMg_ = GFunc.GetRootObj("GameManager");
            GameManager gameManager = gameMg_.GetComponent<GameManager>();
            gameManager.EndGame();
        }
    }
}
