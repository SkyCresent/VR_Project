using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    
    public void GameOverSceneLoad()
    {
        SceneManager.LoadScene("GAMEOVER");
    }

 
    // Start is called before the first frame update
    void Start()
    {
        GameOverSceneLoad();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
