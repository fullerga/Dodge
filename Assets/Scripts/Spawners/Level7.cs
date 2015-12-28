using UnityEngine;
using System.Collections;

public class Level7 : RandomSpawner
{

    // Use this for initialization
    protected override void Start()
    {


        enemies = new ArrayList();

        for (int i = 0; i < 10; i++)
        {
            enemies.Add("zigzagSlow");
        }

    }
}
