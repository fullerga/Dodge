using UnityEngine;
using System.Collections;

public class enemy2Move : MonoBehaviour{

    HealthBar hb;
    spawnerLevel2 spawner;

    void Start(){

        hb = GameObject.Find("health").GetComponent<HealthBar>();
        spawner = GameObject.Find("spawner2").GetComponent<spawnerLevel2>();

        Vector3 current = transform.position;
        float offset = Random.Range(-30, 30);
        if (current.x < 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg - 90 + offset);
        if (current.x > 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg + 90 + offset);
    }

    void Update()
    {
        float movementSpeed = 2F;
        transform.position += transform.up * Time.deltaTime * movementSpeed;
        //transform.Rotate(Vector3.right * 3);
        int xRange = 9;
        int yRange = 9;
        if (transform.position.x > xRange || transform.position.x < -xRange || transform.position.y > yRange || transform.position.y < -yRange)
        {
            Destroy(gameObject);
            spawner.enemyDied();
            if (!hb.IsDead())
            {
                gameStats.points++;
            }
        }
    }
}
