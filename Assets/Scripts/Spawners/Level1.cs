using UnityEngine;
using System.Collections;

public class Level1 : RandomSpawner {

	// Use this for initialization
	protected override void Start () {


        enemies = new ArrayList();

        for(int i=0; i<1; i++)
        {
            enemies.Add("enemy1");
        }
    }
}
