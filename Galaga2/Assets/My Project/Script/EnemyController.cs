using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemy;
    public BulletManager bulletManager;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody>();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GameObject enemyBullet = bulletManager.GetEnemyBullet();
        enemyBullet.gameObject.transform.position = enemy.transform.position;
        enemyBullet.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
        enemyBullet.SetActive(true);
    }
}
