using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _playerSpeed;
    private float _rotationSpeed;
    public int keyCount
    {
        get ; private set;
    }
    private Rigidbody playerRigidbody;
    public bool isPlayerAlive
    {
        get ; private set;
    }
    
    void Start()
    {
        _playerSpeed = 7.5f;
        _rotationSpeed = 5f;
        keyCount = 0;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isPlayerAlive && !UIManager.Instance.isIntructionOn)
        {
            Movement();
            if(Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump();
            }
        }
    }

    // Player movements
    void Movement()
    {
        // Player movement

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movePos = new Vector3(horizontalInput * _playerSpeed , 0 , verticalInput * _playerSpeed);

        playerRigidbody.velocity = transform.TransformDirection(movePos);

        // Player mouse rotation movement

        float mouseX = _rotationSpeed * Input.GetAxis("Mouse X");

        transform.Rotate( 0 , mouseX , 0);
    }

    void PlayerJump()
    {
        // Need to fill
    }

    // Player claiming a key
    public void KeyClaimed()
    {
        UIManager.Instance.GotAKey(keyCount);
        if(keyCount<2)
        {
            UIManager.Instance.EnemyLevelScreen(keyCount);
        }
        keyCount+=1;
        if(keyCount>2){
            GameManager.Instance.EnableLevelEnemy(2);
        }
    }

    // Player death function
    public void GotHit()
    {
        isPlayerAlive=false;
    }

    // Start of the Game
    public void GameStarted()
    {
        isPlayerAlive=true;
    }
}