using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; //생성할 볼의 원본 프리팹
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3.0f; //최대 생성 주기

    public Transform target = default; //발사할 대상
    private float spawnRate = default; //생성 주기
    private float timeAfterSpawn = default; //최근 생성 시점에서 지난 시간
    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격을 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;
        //if => 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같을 때
        if(timeAfterSpawn >= spawnRate)
        {
            //리셋
            timeAfterSpawn = 0f;
            //transform.position 위치와 transform.rotation 회전으로 생성
            GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            //생성된 ball을 target을 향하도록함
            ball.transform.LookAt(target);
            transform.LookAt(target);
            //다음번 생성 간격 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
