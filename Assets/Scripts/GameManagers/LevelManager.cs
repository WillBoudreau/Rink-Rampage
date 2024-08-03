using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    private GameManager gamemanager;
    public GameObject player;
    public  Vector2 LastPOS;
    void Start()
    {
        LastPOS = player.transform.position;
        gamemanager = FindObjectOfType<GameManager>();
    }
    public void LoadScene(string Scenename)
    {
        LastPOS = player.transform.position;
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(Scenename == "Scene-Rink")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Gameplay;
        }
        else if(Scenename == "Scene_Hub")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Gameplay;
        }
        else if(Scenename == "Scene_Dungeon")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Gameplay;
        }
        else if(Scenename == "Scene_Ruins")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Gameplay;
        }
        else if(Scenename == "Scene_EndScene")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Win;
        }
        else if(Scenename == "GameOver_Scene")
        {
            gamemanager.gameScenes = GameManager.GameScenes.GameOver;
        }
        else if(Scenename == "Scene_MainMenu")
        {
            gamemanager.gameScenes = GameManager.GameScenes.MainMenu;
        }
        SceneManager.LoadScene(Scenename);
    }
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    { 
        player.transform.position = GameObject.FindWithTag("SpawnPoint").transform.position; 
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}