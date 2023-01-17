using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_Speed = 8f;
    private Rigidbody bulletRgBody = default;
    // Start is called before the first frame update
    void Start()
    {
        bulletRgBody = gameObject.GetComponent<Rigidbody>();
        bulletRgBody.velocity = transform.forward * bullet_Speed;
        //탄알이 3초 뒤에 스스로 파괴되는 코드
        Destroy(gameObject, 3.0f);
    } //Start
    // Update is called once per frame
    void Update()
    {

    } //Update

    //총알이 무언가와 부딪쳤을 경우 실행되는 함수
    public void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player태그를 가진 경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController player = other.GetComponent<PlayerController>();
            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공한 경우
            if (player == null || player == default)
            {
                return;
            }
            //상대방 PlayerController 컴포넌트의 Die() 메서드 실행
            player.Die();
            //플레이어의 컨트롤을 정상적으로 가져온 경우
            //총알을 맞은 플레이어는 죽는다
           /*  if (player != null)
            {
                player.Die();
            } */
        } //if : 태그가 플레이어인 경우
    }
}
