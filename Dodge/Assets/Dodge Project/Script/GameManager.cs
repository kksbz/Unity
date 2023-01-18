using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using TMPro;


public class GameManager : MonoBehaviour
{
    private GameObject gameOverTextObj = default; //!< 게임오버 시 활성화할 텍스트 게임 오브젝트
    private GameObject timeTextObj = default; //!< 생존 시간을 표시할 텍스트
    private GameObject bestRecordTextObj = default; //!< 최고기록을 표시할 텍스트
    private const string SCENE_NAME = "SampleScene";
    private const string BEST_TIME_RECORD = "BestTime";

    private float surviveTime = default; //생존 시간
    private bool isGameOver = default; //게임오버 상태

    // Start is called before the first frame update
    void Start()
    {
        //{출력할 텍스트 오브젝트를 찾아온다
        GameObject uiObj_ = GFunc.GetRootObj("UiObj");
        timeTextObj = uiObj_.FindChildObj("TimeText");
        gameOverTextObj = uiObj_.FindChildObj("GameOverText");
        bestRecordTextObj = uiObj_.FindChildObj("BestTimeText");
        //}출력할 텍스트 오브젝트를 찾아온다

        //생존 시간과 게임오버 상태 초기화
        surviveTime = 0f;
        isGameOver = false;
        gameOverTextObj.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        //확장메서드 호출함 
        //gameObject.KksFunc();



        /* GameObject targetObj = GFunc.GetRootObj("UiObj");
        if(targetObj == null || targetObj == default)
        {
            Debug.Log("UiObj는 root 오브젝트가 아니라 못찾음");
        }
        else
        {
            Debug.Log("UiObj는 root 오브젝트가 맞아서 찾음");
        } */
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            //게임오버 상태에서 R 키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                GFunc.LoadScene(SCENE_NAME);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GFunc.QuitThisGame(); //static으로 만든 GFunc클래스에서 호출함
            }
        }

        //게임 오버가 아닌 경우

        //생존 시간 갱신
        surviveTime += Time.deltaTime;
        GFunc.SetTmpText(timeTextObj, $"time:{Mathf.FloorToInt(surviveTime)}");
        //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
    } //Update

    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //게임오버 상태로 전환
        isGameOver = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        // gameOverTextObj.SetActive(true);
        gameOverTextObj.transform.localScale = Vector3.one;
        //BEST_TIME_RECORD키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat(BEST_TIME_RECORD);
        //if : 이전까지의 최고 기록보다 현재 생존 시간이 더 크면
        if (bestTime < surviveTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BEST_TIME_RECORD 키로 저장
            PlayerPrefs.SetFloat(BEST_TIME_RECORD, bestTime);
        }
        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        GFunc.SetTmpText(bestRecordTextObj, $"best time:{Mathf.FloorToInt(bestTime)}");
    }

}

