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
        for(int i = 0;i<20;i++)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }

        enemyBullets = new List<GameObject>();
        GameObject enemyBullet = default;
        for(int i =0; i< 30; i++)
        {
            enemyBullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
            enemyBullet.SetActive(false);
            enemyBullets.Add(enemyBullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach(GameObject bullet_ in bullets)
        {
            if(!bullet_.activeInHierarchy)
            {
                return bullet_;
            }
        }
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.SetActive(false);
        bullets.Add(bullet);
        return bullet;
    }

    public GameObject GetEnemyBullet()
    {
        foreach(GameObject bullet_ in enemyBullets)
        {
            if(!bullet_.activeInHierarchy)
            {
                return bullet_;
            }
        }
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        bullet.SetActive(false);
        enemyBullets.Add(bullet);
        return bullet;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
