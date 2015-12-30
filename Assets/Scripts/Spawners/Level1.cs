using UnityEngine;
using System.Collections;

public class Level1 : RandomSpawner
{
	protected override void Start ()
    {
        enemies = new ArrayList();
        for(int i=0; i<2; i++)
        {
            enemies.Add("spikeBall");
        }
    }
}
