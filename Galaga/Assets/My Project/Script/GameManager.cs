using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private GameObject gameOverTextObj = default; //!< 게임오버 시 활성화할 텍스트 게임 오브젝트
    private GameObject scoreTextObj = default; //!< 점수를 표시할 텍스트
    private GameObject bestRecordTextObj = default; //!< 최고기록을 표시할 텍스트
    private const string SCENE_NAME = "PlayScene";
    private const string BEST_SCORE_RECORD = "BestScore";
    private bool isGameOver = default; //게임오버 상태
    private float scoreNum = default;
    // Start is called before the first frame update
    void Start()
    {
        //{출력할 텍스트 오브젝트를 찾아온다
        GameObject uiObj_ = GFunc.GetRootObj("UiObj");
        scoreTextObj = uiObj_.FindChildObj("Score");
        gameOverTextObj = uiObj_.FindChildObj("GameOver");
        bestRecordTextObj = uiObj_.FindChildObj("BestScore");
        //}출력할 텍스트 오브젝트를 찾아온다

        isGameOver = default;
        scoreNum = 0f;
        gameOverTextObj.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
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
                GFunc.SceneLoad(SCENE_NAME);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GFunc.QuitGame(); //static으로 만든 GFunc클래스에서 호출함
            }
        }

        scoreNum += Time.deltaTime;
        GFunc.SetTmpText(scoreTextObj, $"Score:{Mathf.FloorToInt(scoreNum)}");
    }

    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //게임오버 상태로 전환
        isGameOver = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        gameOverTextObj.SetActive(true);
        gameOverTextObj.transform.localScale = Vector3.one;
        //BEST_TIME_RECORD키로 저장된 이전까지의 최고 기록 가져오기
        float bestScore = PlayerPrefs.GetFloat(BEST_SCORE_RECORD);
        //if : 이전까지의 최고 기록보다 현재 생존 시간이 더 크면
        if (bestScore < scoreNum)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestScore = scoreNum;
            //변경된 최고 기록을 BEST_TIME_RECORD 키로 저장
            PlayerPrefs.SetFloat(BEST_SCORE_RECORD, bestScore);
        }
        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        Debug.Log($"겜매니져70줄이 문제임{bestScore}");
        GFunc.SetTmpText(bestRecordTextObj, $"BestScore:{Mathf.FloorToInt(bestScore)}");
    }
}
