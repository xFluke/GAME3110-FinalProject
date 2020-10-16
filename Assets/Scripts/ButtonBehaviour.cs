using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject LoginPanel;

    public TMP_Text usernameInput;
    public TMP_Text passwordInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        LoginPanel.SetActive(true);
        //Debug.Log("Play!");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnLoginButtonPressed()
    {
        if (usernameInput.text.Length > 1 && passwordInput.text.Length > 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        Debug.Log("Username:" + usernameInput.text);
        Debug.Log("Password:" + passwordInput.text);
    }
}
