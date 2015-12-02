using UnityEngine;

public class RandomSpawner : Spawner
{
    
    float timer = 0;

    protected override void Start()
    {
        numEnemies = 5;
    }

    protected override void Update()
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
            destroy();
            Application.LoadLevel("Level2");

        }
    }

    protected override void spawn()
    {
        int rad = 9;
        float f = Random.Range(0, 2 * Mathf.PI);
        float x = Mathf.Cos(f) * rad;
        float y = Mathf.Sin(f) * rad;
        Instantiate(enemy, new Vector2(x, y), Quaternion.identity);
    }
}
