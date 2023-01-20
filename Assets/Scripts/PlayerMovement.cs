using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum CurrentPos {LEFT, CENTRE, RIGHT}
    private CurrentPos currentPos;
    public bool timerDone;

    public bool isGrounded = true;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;


    public GameObject[] lanes = new GameObject[3];

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = startPosition.position;
        currentPos = CurrentPos.CENTRE;

    }
    private void FixedUpdate()
    {

        //Debug.Log("timerDone: " + timerDone);
        
        if (timerDone == true)
        {
            transform.position -= new Vector3(moveSpeed, 0, 0);
        }

        
    }

    public void ResetPlayer()
    {
        transform.position = startPosition.position;
        currentPos = CurrentPos.CENTRE;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void PlayerJump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            Debug.Log("player has jumped");
            isGrounded = false;
        }
    }

    public void MoveLeft()
    {
        switch(currentPos)
        {
            case (CurrentPos.LEFT):

                break;

            case (CurrentPos.CENTRE):
                transform.position = new Vector3(transform.position.x, transform.position.y, lanes[0].transform.position.z);
                currentPos = CurrentPos.LEFT;
                break;

            case (CurrentPos.RIGHT):
                transform.position = new Vector3(transform.position.x, transform.position.y, lanes[1].transform.position.z);
                currentPos = CurrentPos.CENTRE;              
                break;
        }
        Debug.Log(currentPos);
    }

    public void MoveRight()
    {
        switch (currentPos)
        {
            case (CurrentPos.LEFT):
                currentPos = CurrentPos.CENTRE;
                transform.position = new Vector3(transform.position.x, transform.position.y, lanes[1].transform.position.z);
                break;

            case (CurrentPos.CENTRE):
                currentPos = CurrentPos.RIGHT;
                transform.position = new Vector3(transform.position.x, transform.position.y, lanes[2].transform.position.z);
                
                break;

            case (CurrentPos.RIGHT):

                break;
        }
        Debug.Log(currentPos);

    }






}
