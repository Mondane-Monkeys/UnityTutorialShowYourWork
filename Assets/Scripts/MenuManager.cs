using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
//In-Editor only
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{

    public Text highscoreText;
    public TMP_InputField currentNameField;
    public string test;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Load();
        if (GameManager.Instance.highscore > 0)
        {
            highscoreText.text = "Best Score: " + GameManager.Instance.playername + " : " + GameManager.Instance.highscore;
        }
        else
        {
            highscoreText.text = "No Highscore";
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void updateName(){
        GameManager.Instance.currentName = currentNameField.text;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); //editor exit command
#else
        Application.Quit(); //compiled exit command
#endif
    }
    
}
