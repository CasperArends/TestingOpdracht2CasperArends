using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatTracker : MonoBehaviour
{
    public int lifeTotal;
    public int startLife;
    public int coinCounter;
    public bool isFinished = false;
    public GameObject GameOverUI;
    public GameObject VictoryUI;
    public PlayerMovement playerMovement;
    public PlayerInput playerInput;
    public GameObject robotInput;
    //public TextMeshPro

    public GameObject[] lifeImages = new GameObject[3];


    private void Awake()
    {
        GameOverUI.SetActive(false);
        VictoryUI.SetActive(false);
        

    }
    void Start()
    {
        lifeTotal = startLife;
    }

    public void FixedUpdate()
    {
       // coinCounter = coinCounter.ToString
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            PlayerDamage();
            Debug.Log("obstacle collision");
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish Line")
        {
            isFinished = true;
            VictoryUI.SetActive(true);
            robotInput.SetActive(false);
            playerInput.isOn = false;
            Debug.Log("isFinished: " + isFinished + Time.time);
        }

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            AddCoin();

        }
    }

    public void PlayerDamage()
    {
        switch (lifeTotal)
        {
            case (3):
                Destroy(lifeImages[0]);
                playerMovement.ResetPlayer();
                lifeTotal--;
                break;
            case (2):
                Destroy(lifeImages[2]);
                playerMovement.ResetPlayer();
                lifeTotal--;
                break;
            case (1):
                Destroy(lifeImages[1]);
                WaitCoroutine(1);
                GameOverUI.SetActive(true);
                playerInput.isOn = false;

                break;
        }
    }

    public void AddCoin()
    {
        coinCounter++;
        Debug.Log("coin added, current coins: " + coinCounter);
    }

    IEnumerator WaitCoroutine(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

}
