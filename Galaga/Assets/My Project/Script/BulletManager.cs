using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject enemyBulletPrefab;
    private List<GameObject> bullets;
    private List<GameObject> enemyBullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        GameObject bullet = default;
        for (int i = 0; i < 20; i++)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.SetActive(false);
            bullets.Add(bullet);
            bullet.transform.parent = gameObject.transform.Find("PlayerBullet");
        }

        enemyBullets = new List<GameObject>();
        GameObject enemyBullet = default;
        for (int i = 0; i < 50; i++)
        {
            enemyBullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
            enemyBullet.SetActive(false);
            enemyBullets.Add(enemyBullet);
            enemyBullet.transform.parent = gameObject.transform.Find("EnemyBullet");
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet_ in bullets)
        {
            if (!bullet_.activeInHierarchy)
            {
                return bullet_;
            }
        }
        GameObject bullet = default;
        bullet.SetActive(false);
        bullets.Add(bullet);
        return bullet;
    }

    public GameObject GetEnemyBullet()
    {
        GameObject temp = default;
        foreach (GameObject bullet_ in enemyBullets)
        {
            if (!bullet_.activeInHierarchy)
            {
                temp = bullet_;
                return temp;
            }
        }
        return temp;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
