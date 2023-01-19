using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemy;
    private float spwanTime = 0.5f; //탄발사 주기
    private float spwanLate = 0f; //탄 발사시점에서 지난 시간
    public BulletManager bulletManager;
    public Transform taget;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody>();
        //
        Scene activeScene_ = SceneManager.GetActiveScene();
        GameObject[] rootObj_ = activeScene_.GetRootGameObjects();

        GameObject targetObj = default;
        GameObject targetObj_2 = default;
        foreach(GameObject obj_ in rootObj_)
        {
            if(obj_.name.Equals("BulletManager"))
            {
                targetObj = obj_;
                break;
            }
            else if(obj_.name.Equals("Player"))
            {
                targetObj_2 = obj_;
            }
        }
        bulletManager = targetObj.GetComponent<BulletManager>();
        taget = targetObj_2.GetComponent<Transform>();
        //


        spwanLate = 0f;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    } //Update

    public void Shoot()
    {
        //0초부터 Time.deltaTime을 더함
        spwanLate = spwanLate + Time.deltaTime;
        //spwanLate가 탄발사 주기보다 크거나 같아질때 실행
        if (spwanTime <= spwanLate)
        {
            //spwanLate 0으로 초기화
            spwanLate = 0f;
            //탄창에서 한발 꺼냄 오브젝트풀링
            GameObject enemyBullet = bulletManager.GetEnemyBullet();
            if(enemyBullet == null || enemyBullet == default)
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
}
