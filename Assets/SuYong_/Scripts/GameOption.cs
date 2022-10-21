using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOption : MonoBehaviour
{
    public GameObject option;
   
   public void BackOption()
    {
        option.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


}
