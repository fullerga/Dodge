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
        if (timer > 1 && enemies.Count > 0)
        {
            spawn();
            timer = 0;
            numEnemCreated++;
        }

        checkIfDone();
    }

    protected override void spawn()
    {
        var position = RandomPositionOnCircle(9f);
        Instantiate(Resources.Load("enemies/" + getNextEnemy()), position, GetRotation(position));
    }

    Vector2 RandomPositionOnCircle(float radius)
    {
        var f = Random.Range(0, 2 * Mathf.PI);
        var x = Mathf.Cos(f) * radius;
        var y = Mathf.Sin(f) * radius;
        return new Vector2(x, y);
    }

    Quaternion GetRotation(Vector2 pos)
    {
        var offset = Random.Range(-30, 30);
        var angle = pos.x < 0 ?
            Mathf.Atan(pos.y / pos.x) * Mathf.Rad2Deg - 90 + offset :
            Mathf.Atan(pos.y / pos.x) * Mathf.Rad2Deg + 90 + offset;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
