using UnityEngine;
using System.Collections;

public class bulletMove : MonoBehaviour {

    healthBar hb;
    spawnerLevel1 spawner;

    void Start () {

        hb = GameObject.Find("health").GetComponent<healthBar>();
        spawner = GameObject.Find("Spawner").GetComponent<spawnerLevel1>();

        Vector3 current = transform.position;
        float offset = Random.Range(-30, 30);
        if(current.x<0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y/current.x)*Mathf.Rad2Deg-90+offset);
        if (current.x > 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg + 90+offset);
    }

    void Update()
    {
		float movementSpeed = getSpeed ();
		print (movementSpeed);
        transform.position += transform.up * Time.deltaTime * movementSpeed;
        int xRange = 9;
        int yRange = 9;
        if (transform.position.x>xRange || transform.position.x < -xRange || transform.position.y > yRange || transform.position.y < -yRange)
        {
            Destroy(gameObject);

            spawner.enemyDied();

            if (!hb.isDead())
            {
                gameStats.points++;
            }
        }
    }

	float getSpeed()
	{
		print (powerUpManager.isFast);
		if (powerUpManager.isSlow)
			return 1F;
		if (powerUpManager.isFast)
			return 3F;
		return 2F;
	}
}
