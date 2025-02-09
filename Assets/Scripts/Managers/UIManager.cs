using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get{
            if(_instance==null)
            {
                Debug.LogError("Game Manager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance=this;
    }
    private PlayerController playerController;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public GameObject pauseGameScreen;
    public bool isIntructionOn;
    public bool isGamePaused;
    private int _screenLevel;
    public GameObject[] keyCountObjects;
    public GameObject[] enemyLevelInstructions;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        isIntructionOn=false;
        isGamePaused=false;
    }

    void Update()
    {
        if(!GameManager.Instance.isIntroScreeEnabled && !isIntructionOn && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTheGame();
        }
        if(isIntructionOn)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isIntructionOn=false;
                enemyLevelInstructions[_screenLevel].SetActive(false);
                if(_screenLevel==1){
                    EnemyLevelScreen(2);
                }
            }
        }
    }

    // Game won screen
    public void GameWon()
    {
        gameWonScreen.SetActive(true);
    }

    // Game Over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    // Pausing the game
    private void PauseTheGame()
    {
        pauseGameScreen.SetActive(true);
        isGamePaused=true;
        GetComponent<PlayerInventoryManager>().DisablePlayerInventory();
        Time.timeScale=0;
    }

    // Enabling image for each key collected
    public void GotAKey(int keyIndex)
    {
        keyCountObjects[keyIndex].SetActive(true);
    }

    public void EnemyLevelScreen(int screenLevel)
    {
        isIntructionOn=true;
        _screenLevel = screenLevel;
        enemyLevelInstructions[screenLevel].SetActive(true);
    }

    // Resume the game
    public void ResumeGame()
    {
        Time.timeScale=1;
        pauseGameScreen.SetActive(false);
        isGamePaused=false;
        GetComponent<PlayerInventoryManager>().EnablePlayerInventory();
    }

    // Restarting the game
    public void RestartGame()
    {
        Time.timeScale=1;               // Its necessary since time scale is set to 0 in UIManager
        SceneManager.LoadScene(1);
    }

    // Quiting the game
    public void QuitGame()
    {
        Time.timeScale=1;               // Its necessary since time scale is set to 0 in UIManager
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void EnablePlayerInventory()
    {
        GetComponent<PlayerInventoryManager>().EnablePlayerInventory();
    }
}
