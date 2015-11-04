﻿using UnityEngine;
using System.Collections;

public class bulletMove : MonoBehaviour {

	void Start () {
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
        int range = 10;
        if(transform.position.x>range || transform.position.x < -range || transform.position.y > range || transform.position.y < -range)
        {
            Destroy(gameObject);
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
