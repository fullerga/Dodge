using UnityEngine;
using System.Collections;

public class powerUpManager : MonoBehaviour {
	public static bool isInvincible;
	public static bool isSlow;
	public static bool isFast;
	public static bool isReverse;

	static float powerUpStartTime;
	
	void Start () {
		Reset ();
	}
	
	void Update () {
		if (PowerUpOver ()) {
			Reset ();
		}
	}
	
	public static void SetPowerUp(string tag){
		Reset ();
		switch (tag) {
		case "invincible" : 
			isInvincible = true;
			break;
		case "slower" : 
			isSlow = true;
			break;
		case "faster" : 
			isFast = true;
			break;
		case "reverse" : 
			isReverse = true;
			break;
		default: 
			throw new UnityException("Could not find powerup for " + tag);
		};
	}
	
	static void Reset(){
		powerUpStartTime = Time.time;
		isInvincible = false;
		isSlow = false;
		isFast = false;
		isReverse = false;
	}
	
	static bool PowerUpOver(){
		var diff = Time.time - powerUpStartTime;
		int seconds =  (int)diff % 60;
		return seconds >= 10;
	}
}
