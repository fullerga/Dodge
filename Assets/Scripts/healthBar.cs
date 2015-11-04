using UnityEngine;
using System.Collections;

public class healthBar : MonoBehaviour {

    static float width = 7.8f;
    static int maxHealth = 5;
    float health;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}

    public void subHealth()
    {
        health -= 1;
        transform.localScale = new Vector3(health / maxHealth, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(transform.position.x - width / (maxHealth * 2), transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public bool isDead()
    {
        if (health == 0)
        {
            return true;
        }
        return false;
    }
}
