using UnityEngine;
using System.Collections;

public class Level8 : RandomSpawner
{
    protected override void Start()
    {
        enemies = new ArrayList();
        for (int i = 0; i < 10; i++)
        {
            enemies.Add("zigzagFast");
        }
    }
}
