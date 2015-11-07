using UnityEngine;
using System.Collections;

public class spawnerLevel1 : MonoBehaviour, Spawner
{

    int numEnemies = 4;
    int numEnemCreated = 0;
    int numEnemDead = 0;

    public GameObject square;
    float timer = 0;

    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 && numEnemCreated < numEnemies)
        {
            spawn();
            timer = 0;
            numEnemCreated++;
        }

        if (numEnemCreated == numEnemies && numEnemies == numEnemDead)
        {
            DontDestroyOnLoad(GameObject.Find("Player"));
            DontDestroyOnLoad(GameObject.Find("health"));
            DontDestroyOnLoad(GameObject.Find("healthBarEmpty"));
            DontDestroyOnLoad(GameObject.Find("Canvas"));
            DontDestroyOnLoad(GameObject.Find("EventSystem"));
            DontDestroyOnLoad(GameObject.Find("level"));

            gameStats.level++;

            Application.LoadLevel("Level2");
        }
    }

    public void spawn()
    {

        int rad = 9;
        float f = Random.Range(0, 2 * Mathf.PI);
        float x = Mathf.Cos(f) * rad;
        float y = Mathf.Sin(f) * rad;
        Instantiate(square, new Vector2(x, y), Quaternion.identity);
    }

    public void EnemyDied()
    {
        numEnemDead++;
    }
}
