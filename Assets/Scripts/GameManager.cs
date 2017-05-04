using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Singleton Class
public class GameManager : MonoBehaviour
{

    public int currentLevel = 0;

    private static GameManager instance;

    // Use this for initialization
    void Start()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void CompleteLevel()
    {
        // Increase the level by 1
        instance.currentLevel++;
        // Switch the scene to the next level
        SceneManager.LoadScene(instance.currentLevel);

    }

}
