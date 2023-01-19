using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //유니티에디터, 어플리케이션 종료함수
    public static void QuitThisGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    } //QuitThisGame

    //다른 씬을 로드하는 함수
    public static void LoadScene(string sceneName_)
    {
        SceneManager.LoadScene(sceneName_);
    }
}
