using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;
    private List<GameObject> enemys;

    private float spwanLate = 0f;
    private float spwanTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //적생성해서 리스트에 넣음
        spwanLate = 0f;
        enemys = new List<GameObject>();
        GameObject enemy = default;
        for (int i = 0; i < 15; i++)
        // for (int i = 0; i < 5; i++)
        {
            if (0 <= i && i < 5)
            {
                enemy = Instantiate(enemy_1, transform.position, transform.rotation);
            }
            else if (5 <= i && i < 10)
            {
                enemy = Instantiate(enemy_2, transform.position, transform.rotation);
            }
            else if (10 <= i && i < 15)
            {
                enemy = Instantiate(enemy_3, transform.position, transform.rotation);
            }
            enemy.SetActive(false);
            enemys.Add(enemy);
            //enemy.transform.parent = enemy.transform.Find("EnemySpwan");
        }
    } //Start

    //적리스트에서 한개 리턴받는 함수
    public GameObject GetEnemy()
    {
        /* int rN = Random.RandomRange(0, enemys.Count);
        while(!enemys[rN].activeInHierarchy)
        {
            if(!enemys[rN].activeInHierarchy)
            {
                return enemys[rN];
            }
            rN = Random.RandomRange(0, enemys.Count);
        } */
        GameObject newEnemy = default;
        int rN = Random.RandomRange(0, enemys.Count);
        Debug.Log(rN);
        if(!enemys[rN].activeInHierarchy)
        {
            newEnemy = enemys[rN];
        }
        return newEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        SpwanEnemy();
    }

    //적스폰함수
    public void SpwanEnemy()
    {
        spwanLate += Time.deltaTime;
        if (spwanTime <= spwanLate)
        {
            spwanLate = 0f;
            GameObject enemyObj = GetEnemy();
            if(enemyObj == null || enemyObj == default) //예외처리
            {
                return;
            }
            else
            {
                enemyObj.transform.position = new Vector3(0f, 0f, 13f);
                enemyObj.SetActive(true);
            }
        }
    }
}
