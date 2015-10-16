using UnityEngine;
using System.Collections;

public class bulletMove : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (!gameSettings.isPlaying)
        {
            return;
        }

        Vector3 current = transform.position;

        float offset = Random.Range(-30, 30);

        if(current.x<0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y/current.x)*Mathf.Rad2Deg-90+offset);
        if (current.x > 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg + 90+offset);
    }

    void Update()
    {

        if (!gameSettings.isPlaying)
        {
            return;
        }

        float movementSpeed = 2F;
        transform.position += transform.up * Time.deltaTime * movementSpeed;

        int range = 10;
        
        if(transform.position.x>range || transform.position.x < -range || transform.position.y > range || transform.position.y < -range)
        {
            Destroy(gameObject);
        }
    }
}
