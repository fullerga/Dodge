using UnityEngine;
using System.Collections;

public class Level3 : RandomSpawner
{

    // Use this for initialization
    protected override void Start()
    {


        enemies = new ArrayList();

        for (int i = 0; i < 5; i++)
        {
            enemies.Add("enemy3");
        }
        for (int i = 0; i < 5; i++)
        {
            enemies.Add("enemy4");
        }

    }
}
