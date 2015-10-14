using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    public GameObject square;
    float timer = 0;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            spawn();
            timer = 0;
        }
	}

    public void spawn()
    {
        float f = Random.Range(0, 2*Mathf.PI);
        float x = Mathf.Cos(f)*10;
        float y = Mathf.Sin(f)*10;
        Instantiate(square, new Vector2(x, y), Quaternion.identity);
    }
}
