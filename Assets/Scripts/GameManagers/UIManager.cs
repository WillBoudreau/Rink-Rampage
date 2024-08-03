using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject PauseUI;
    public GameObject WinUI;
    public GameObject GamePlayUI;
    public GameObject OptionsUI;
    public GameObject GameOverUI;
    bool CursorVisisble;
    // Update is called once per frame
    void Update()
    {
        if(CursorVisisble == true)
        {
            Cursor.visible = true;
        }
    }
    public void MainMenuUI()
    {
        CursorVisisble = true;
        MainUI.SetActive(true);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);
        GamePlayUI.SetActive(false);
        OptionsUI.SetActive(false);
        GameOverUI.SetActive(false);
    }
    public void Pause()
    {
        CursorVisisble = true;
        MainUI.SetActive(false);
        PauseUI.SetActive(true);
        WinUI.SetActive(false);
        GamePlayUI.SetActive(false);
        OptionsUI.SetActive(false);
        GameOverUI.SetActive(false);
    }
    public void Win()
    {
        CursorVisisble = true;
        MainUI.SetActive(false);
        PauseUI.SetActive(false);
        WinUI.SetActive(true);
        GamePlayUI.SetActive(false);
        OptionsUI.SetActive(false);
        GameOverUI.SetActive(false);
    }
    public void GamePlay()
    {
        Cursor.visible = true;
        MainUI.SetActive(false);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);
        GamePlayUI.SetActive(true);
        OptionsUI.SetActive(false);
        GameOverUI.SetActive(false);
    }
    public void Options()
    {
        Debug.Log("Options Menu");
        CursorVisisble = true;
        MainUI.SetActive(false);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);
        GamePlayUI.SetActive(false);
        OptionsUI.SetActive(true);
        GameOverUI.SetActive(false);
    }
    public void GameOver()
    {
        CursorVisisble = true;
        MainUI.SetActive(false);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);
        GamePlayUI.SetActive(false);
        OptionsUI.SetActive(false);
        GameOverUI.SetActive(true);
    }
}