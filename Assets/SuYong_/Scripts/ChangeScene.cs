using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string nextScene;
    public GameObject mainMenu;
    public GameObject opt;

    public void StartScene()
    {
        SceneManager.LoadScene(nextScene);   // 게임 씬 이름 설정
    }
    

    public void OpenOption()
    {
        mainMenu.SetActive(false);
        opt.SetActive(true);
    }

   
    public void CloseOption()
    {
        opt.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

  
}
