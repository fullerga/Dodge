using UnityEngine;
using System.Collections;

public class gameSettings : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject mainScreen;
    public GameObject gameScreen;
    public static bool isMainScreen = true;
    public static bool isPlaying = false;
    public static bool isDead = false;
    public static bool needDeadScreen = false;
    public static bool needMainScreen = true;
    public static bool needGameScreen = false;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMainScreen)
            restart();

        if (isDead)
            dead();

        if (isPlaying)
            startGame();
    }

    void startGame()
    {
        if (needGameScreen == true)
        {
            Instantiate(gameScreen, new Vector3(0, 0, 1), Quaternion.identity);
            needGameScreen = false;
        }
    }

    void dead()
    {
        if (needDeadScreen)
        {
            Instantiate(deathScreen, new Vector2(0, 0), Quaternion.identity);
            needDeadScreen = false;
        }

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("bullet");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

    }

    void restart()
    {
        if (needMainScreen)
        {
            Instantiate(mainScreen, new Vector2(0, 0), Quaternion.identity);

            needMainScreen = false;
        }
    }
}