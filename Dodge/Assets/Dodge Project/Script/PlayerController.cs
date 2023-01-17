using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody = default;
    private float player_speed = 8.0f;
    // Start is called before the first frame update
    void Start() //런타임때만 실행됨 에디터타임때는 none으로 표시됨
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();

        /* Vector3 firstPoint = new Vector3(100f, 0f, 0f);
        Vector3 secondPoint = new Vector3(500f, 0f, 0f);
        float distance = (firstPoint - secondPoint).magnitude; //magnitude => 두점사이의 거리계산
        Debug.Log($"두 점 사이의 거리는 : {distance}"); */
    } //Start

    // Update is called once per frame
    void Update()
    {
        float xInPut = Input.GetAxis("Horizontal");
        float zInPut = Input.GetAxis("Vertical");

        float xSpeed = xInPut * player_speed;
        float zSpeed = zInPut * player_speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
    } //Update

    //! 이전에 움직이던 방식을 캐싱해 놓은 함수
    /* private void LegacyMove()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(new Vector3(0, 0, player_speed));
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(new Vector3(0, 0, -player_speed));
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(new Vector3(player_speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(new Vector3(-player_speed, 0, 0));
        }
    } //LegacyMove */

    //플레이어가 사망했을때 호출하는 함수
    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    } //Die
}
