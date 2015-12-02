using UnityEngine;

public abstract class Spawner: MonoBehaviour
{

    protected int numEnemies = 10;
    protected int numEnemCreated = 0;
    protected int numEnemDead = 0;

    public GameObject enemy;

    protected abstract void Start();
    protected abstract void Update();
    protected abstract void spawn();

    public void EnemyDied()
    {
        numEnemDead++;
    }

    protected void destroy()
    {
        DontDestroyOnLoad(GameObject.Find("Player"));
        DontDestroyOnLoad(GameObject.Find("health"));
        DontDestroyOnLoad(GameObject.Find("healthBarEmpty"));
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        DontDestroyOnLoad(GameObject.Find("level"));

        gameStats.level++;
    }
}
