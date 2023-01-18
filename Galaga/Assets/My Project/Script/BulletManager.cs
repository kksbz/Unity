using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab; //탄 프리펩
    //public int bulletNum; //탄 갯수
    private List<GameObject> bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        SetBullet();
    }
    public void SetBullet()
    {
        GameObject bullet;
        for(int i = 0; i < 20; i++)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }
    public GameObject GetBullet()
    {
        GameObject bullet_1 = default;
        foreach(GameObject bullet in bullets)
        {
            if(!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return bullet_1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
