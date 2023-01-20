using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputController
{
    
    [SerializeField] private PlayerMovement playerMovement;
    public bool firstInput = false;
    public bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.PlayerJump();
                firstInput = true;
                Debug.Log("firstInput: " + firstInput);

            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerMovement.MoveLeft();
                firstInput = true;
                Debug.Log("firstInput: " + firstInput);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerMovement.MoveRight();
                firstInput = true;
                Debug.Log("firstInput: " + firstInput);
            }
        }
    }


}
