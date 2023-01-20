using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestPlaythrough
{
    [SerializeField] private StatTracker statTracker;

    [SetUp]
    public void Setup()
    {

        SceneManager.LoadScene("SampleScene");

    }
    //verslag
    [UnityTest]
    public IEnumerator CheckIfRobotInputTurnsOnAfterCountDown()
    {

        yield return new WaitForSeconds(4f);
        Assert.AreEqual(GameObject.Find("RobotInput").activeSelf, true);


    }
    //verslag
    [UnityTest]
    public IEnumerator TestPlayInputsTurnedOffEnd()
    {

        yield return new WaitForSeconds(15f);
        Assert.AreEqual(GameObject.Find("PlayerInput").GetComponent<PlayerInput>().isOn, false);


    }
    //verslag
    [UnityTest]
    public IEnumerator TestPlaythroughWithCheckIfFinished()
    {
        
        yield return new WaitForSeconds(15f);
        Assert.AreEqual(GameObject.Find("Player").GetComponent<StatTracker>().isFinished, true);
        

    }

    [UnityTest]
    public IEnumerator CheckIfLifeIsRightAmount()
    {
        yield return new WaitForSeconds(3f);
        Assert.AreEqual(GameObject.Find("Player").GetComponent<StatTracker>().lifeTotal, GameObject.Find("Player").GetComponent<StatTracker>().startLife);


    }





    // A Test behaves as an ordinary method
    /*[Test]
    public void TestPlaythroughSimplePasses()
    {
        GameObject player = GameObject.Instantiate(Resources.Load("Player") as GameObject);

        statTracker = player.GetComponent<StatTracker>();
        Assert.AreEqual(statTracker.lifeTotal, 3);
        GameObject.Destroy(player);
    }*/

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
}
