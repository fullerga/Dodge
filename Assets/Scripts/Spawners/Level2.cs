using UnityEngine;
using System.Collections;

public class Level2 : RandomSpawner
{

    // Use this for initialization
    protected override void Start()
    {


        enemies = new ArrayList();

        for (int i = 0; i < 5; i++)
        {
            enemies.Add("enemy1");
        }
        for (int i = 0; i < 5; i++)
        {
            enemies.Add("enemy2");
        }

    }
}
