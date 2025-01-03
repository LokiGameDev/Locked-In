using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject[] enemyLevelObjects;
    public GameObject introScreen;
    public bool isIntroScreeEnabled
    {
        get; private set;
    }
    public static GameManager Instance
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
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        introScreen.SetActive(true);
        isIntroScreeEnabled=true;
    }

    void Update()
    {
        // Intro scene checking

        if(isIntroScreeEnabled && Input.GetKeyDown(KeyCode.E))
        {
            introScreen.SetActive(false);
            isIntroScreeEnabled=false;
            playerController.GameStarted();     // Trigger the game started function
        }
    }

    // Enabling each level of enemies after each key gets collected
    public void EnableLevelEnemy(int enemyLeveIndex)
    {
        enemyLevelObjects[enemyLeveIndex].SetActive(true);
    }
}
