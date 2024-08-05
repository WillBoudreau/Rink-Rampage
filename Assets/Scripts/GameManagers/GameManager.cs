using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameScenes { MainMenu, PauseMenu , GameOver , Win, Gameplay, Options};

    public GameScenes gameScenes;
    public UIManager uiManager;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        gameScenes = GameScenes.MainMenu;
        Player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
        switch(gameScenes)
        {
            case GameScenes.MainMenu:
                MainMenu();
                //Player.GetComponent<SpriteRenderer>().enabled = false;
                Player.GetComponentInChildren<FPS_Controler>().enabled = false;
                Player.GetComponent<CharacterController>().enabled = false;
                break;
            case GameScenes.PauseMenu:
                Pause();
                break;
            case GameScenes.Win:
                Win();
                break;
            case GameScenes.Gameplay:
                GamePlay();
                break;
            case GameScenes.GameOver:
                GameOver();
                break;
            case GameScenes.Options:
                Options();
                break;
        }
    }
    public void MainMenu()
    {
        gameScenes = GameScenes.MainMenu;
        uiManager.MainMenuUI();
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        gameScenes = GameScenes.PauseMenu;
        uiManager.Pause();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GamePlay();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        gameScenes = GameScenes.Gameplay;
    }
    public void OptionBack()
    {
        gameScenes = GameScenes.MainMenu;
        uiManager.MainMenuUI();
    }
    public void Win()
    {
        Player.SetActive(false);
        Time.timeScale = 0.0f;
        gameScenes = GameScenes.Win;
        uiManager.Win();
    }
    public void GamePlay()
    {
        Time.timeScale = 1.0f;
        uiManager.GamePlay();
        Player.GetComponentInChildren<FPS_Controler>().enabled = true;
        Player.GetComponent<CharacterController>().enabled = true;
        //Player.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void Options()
    {
        gameScenes = GameScenes.Options;
        uiManager.Options();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        gameScenes = GameScenes.GameOver;
        uiManager.GameOver();
    }
}
