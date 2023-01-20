using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemy;
    public BulletManager bulletManager;
    public Transform taget;

    private float moveTime = 3f;
    private float moving = 0f;
    private float enemySpeed = 0f;

    private Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody>();
        GameObject bulletMg_ = GFunc.GetRootObj("BulletManager");
        bulletManager = bulletMg_.GetComponent<BulletManager>();
        GameObject player_ = GFunc.GetRootObj("Player");
        taget = player_.GetComponent<Transform>();
        //랜덤좌표담을 오브젝트
        targetpos = new Vector3(Random.RandomRange(-20, 20),0,Random.RandomRange(9, 11));
        enemySpeed = 3f;
        //4초후에 슛쏘고 2초마다 반복
        InvokeRepeating("Shoot", 5f, 2f);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        GameManager.scoreNum += 500;
    }
    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        ChangePos();
    } //Update

    private void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetpos, enemySpeed * Time.deltaTime);
    }
    private void ChangePos()
    {
        moving += Time.deltaTime;
        if(moveTime <= moving)
        {
            
            targetpos = new Vector3(Random.RandomRange(-20,20),0,Random.RandomRange(-7,11));
            enemySpeed = Random.RandomRange(1,5);
            moving = 0f;
        }
    }
    public void Shoot()
    {
        //탄창에서 한발 꺼냄 오브젝트풀링
        GameObject enemyBullet = bulletManager.GetEnemyBullet();
        if (enemyBullet == null || enemyBullet == default)
        {
            return;
        }
        //탄알의 포지션과 로테이션 재설정
        enemyBullet.transform.position = enemy.transform.position;
        enemyBullet.transform.LookAt(taget);
        EnemyBullet bc = enemyBullet.GetComponent<EnemyBullet>();
        //Velocity값 초기화
        bc.SetVelocity();
        transform.LookAt(taget);
        //Debug.Log($"{taget.position}");
        //액티브활성
        enemyBullet.SetActive(true);
    }
}
