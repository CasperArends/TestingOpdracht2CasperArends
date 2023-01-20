using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float currentTime;
    public PlayerInput playerInput;
    public RobotInput robotInput;
    public PlayerMovement playerMovement;
    private bool isTriggered = false;
    void Start()
    {
        playerInput.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <= 0 && isTriggered == false)
        {
            currentTime = 0;
            isTriggered = true;
            playerInput.isOn = true;
            StartGame();
        }

    }

    public void StartGame()
    {
        
        playerMovement.timerDone = true;
        playerInput.isOn = true;
        robotInput.isOn = true;
    }
    
}
