using System;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    readonly float Width = 7.8f;
    readonly int MaxHealth = 5;
    int Health;
    Vector3 IntialScale;
    Vector3 IntialPosition;

	void Start () {
        Health = MaxHealth;
	    IntialScale = transform.localScale;
	    IntialPosition = transform.localPosition;
	}

    public void IncHealth()
    {
        Health = MaxHealth;
        transform.localScale = IntialScale;
        transform.position = IntialPosition;
    }

    public void SubHealth()
    {
        Health -= 1;
        transform.localScale = new Vector3((float)Health / MaxHealth, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(transform.position.x - Width / (MaxHealth * 2), transform.position.y,
            transform.position.z);
    }

    public bool HasFullHealth()
    {
        return Health == 5;
    }

    public bool HasLowHealth()
    {
        return Health == 1;
    }

    public bool IsDead()
    {
        return Health == 0;
    }
}
