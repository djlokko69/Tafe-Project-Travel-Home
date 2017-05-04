using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static int currentScore;
    public static int highScore;

    public static int currentLevel = 1;
    public static int unlockedLevel;


    public static void CompleteLevel()
    {
        if (currentLevel < 2)
        {
            currentLevel += 1;
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            print("You Win!");
        }
    }
    // Use this for initialization
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
}
