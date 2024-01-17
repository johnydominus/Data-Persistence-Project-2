using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerInput;
    public GameObject errorMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName()
    {
        GameManager.Instance.playerName = playerInput.text;
    }

    public void LoadGame()
    {
        if(GameManager.Instance.playerName == "" || GameManager.Instance.playerName == null) 
        {
            StartCoroutine(showEmptyNameErrorMessage());
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        GameManager.Instance.SaveHighScore();
    }

    IEnumerator showEmptyNameErrorMessage()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        errorMessage.SetActive(false);
    }
}
