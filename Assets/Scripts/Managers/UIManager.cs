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
    public bool isIntructionOn;
    private int _screenLevel;
    public GameObject[] keyCountObjects;
    public GameObject[] enemyLevelInstructions;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        isIntructionOn=false;
    }

    void Update()
    {
        if(!playerController.isPlayerAlive && !GameManager.Instance.isIntroScreeEnabled)
        {
            gameOverScreen.SetActive(true);
        }
        if(isIntructionOn)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isIntructionOn=false;
                enemyLevelInstructions[_screenLevel].SetActive(false);
                if(_screenLevel==1){
                    FinalEnemyLevelScreen();
                }
                if(_screenLevel<2)
                {
                    GameManager.Instance.EnableLevelEnemy(_screenLevel);
                }
            }
        }
    }

    // Game won screen
    public void GameWon()
    {
        gameWonScreen.SetActive(true);
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

    private void FinalEnemyLevelScreen()
    {
        EnemyLevelScreen(2);
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
}
