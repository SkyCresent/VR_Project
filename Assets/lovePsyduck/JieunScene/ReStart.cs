using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    public void OnClickButton()
    {
        //SceneManager.LoadScene(nextSceneName);
        EditorApplication.isPlaying = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
