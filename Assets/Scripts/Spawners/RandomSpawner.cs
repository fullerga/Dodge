using UnityEngine;

public class RandomSpawner : Spawner
{
    
    float timer = 0;

    protected override void Start()
    {
        pickRandom = true;
        //Override to set enemies e.g.
        //enemies = new string[] { "enemy2"};
    }

    protected override void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 && enemies.Count>0)
        {
            spawn();
            timer = 0;
            numEnemCreated++;
        }

        checkIfDone();
    }

    protected override void spawn()
    {
        int rad = 9;
        float f = Random.Range(0, 2 * Mathf.PI);
        float x = Mathf.Cos(f) * rad;
        float y = Mathf.Sin(f) * rad;
        string temp = getNextEnemy();
        Instantiate(Resources.Load("enemies/"+temp), new Vector2(x, y), Quaternion.identity);
    }
}
