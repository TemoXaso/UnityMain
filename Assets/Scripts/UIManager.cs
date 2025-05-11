using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject InGamePanel;
    public GameObject Camera;
    public GameObject Camera2;
    public Button button;
    public Button Resumebutton;
    public Toggle toggle;

    void Start()
    {
        button.onClick.AddListener(StartGameMethod);
        Resumebutton.onClick.AddListener(Resume);
        toggle.onValueChanged.AddListener(LogToggle);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
    }
    void StartGameMethod()
    {
        StartMenu.SetActive(false);
        Camera.SetActive(true);
        Camera2.SetActive(false);
        InGamePanel.SetActive(true);
    }
    void Pause(){
        InGamePanel.SetActive(false);
        GameManager.Instance.gamepaused = true;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    void Resume(){
        PauseMenu.SetActive(false);
        GameManager.Instance.gamepaused = false;
        Time.timeScale = 1;
        InGamePanel.SetActive(true);
    }
    public void LogToggle(bool value){
        Debug.Log(value);
    }
}
