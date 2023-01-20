using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class RobotInput : InputController
{
    [SerializeField] private PlayerMovement playerMovement;
    private enum PlayerInputEnum {LEFT, RIGHT, JUMP}

    public bool isTriggered = true;
    public bool isOn = false;

    private void Start()
    {





    }
    private void Update()
    {
        if (isOn == true && isTriggered == false)
        {
            StartCoroutine(RoboWaitForSeconds(2.7f, PlayerInputEnum.LEFT));
            StartCoroutine(RoboWaitForSeconds(4.2f, PlayerInputEnum.RIGHT));
            StartCoroutine(RoboWaitForSeconds(4.8f, PlayerInputEnum.RIGHT));
            StartCoroutine(RoboWaitForSeconds(7.5f, PlayerInputEnum.JUMP));
            isTriggered = true;
        }
    }

    IEnumerator RoboWaitForSeconds(float timeToWait, PlayerInputEnum playerMovementEnum)
    {

        Debug.Log("started coroutine " + Time.time);
        yield return new WaitForSeconds(timeToWait);
        switch (playerMovementEnum)
        {
            case (PlayerInputEnum.LEFT):
                playerMovement.MoveLeft();
                break;

            case (PlayerInputEnum.RIGHT):
                playerMovement.MoveRight();
                break;

            case (PlayerInputEnum.JUMP):
                playerMovement.PlayerJump();
                break;
        }
        
        
        Debug.Log("ended Corourinte " + Time.time);
    }
}
