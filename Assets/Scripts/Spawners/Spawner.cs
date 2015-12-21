﻿using System.Collections;
using UnityEngine;

public abstract class Spawner: MonoBehaviour
{

    protected int numEnemCreated = 0;
    protected int numEnemDead = 0;
    protected ArrayList enemies;
    protected bool pickRandom; //should the enemies not be generated base on order in list

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

    protected void checkIfDone()
    {
        if (enemies.Count == 0 && numEnemCreated == numEnemDead)
        {
            destroy();
            Application.LoadLevel("Level"+gameStats.level);

        }
    }

    protected string getNextEnemy()
    {
        if (pickRandom==true)
        {
            System.Random r = new System.Random();
            int pos = r.Next(0, 100); //for ints
            print(pos);
         
            string temp = (string) enemies[pos];
            enemies.RemoveAt(pos);
            return temp;
        }
        else
        {
            string temp = (string)enemies[0];
            enemies.RemoveAt(0);
            return temp;
        }
    }
}