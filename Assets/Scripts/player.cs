using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public GameObject explosion;

    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
	private bool isReverse;

	void Start () {
		isReverse = false;
	}

    void OnMouseDown()
    {
        plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        v3Offset = transform.position - ray.GetPoint(dist);
    }

    void OnMouseDrag()
    { 
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float dist;
		plane.Raycast (ray, out dist);
		var v3Pos = ray.GetPoint (dist);
		v3Pos = powerUpManager.isReverse ? -v3Pos : v3Pos;
		transform.position = v3Pos + v3Offset;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "enemy" && !powerUpManager.isInvincible) {
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		} else if (col.gameObject.tag == "enemy") {
			Destroy (col.gameObject);
		} else {
			powerUpManager.SetPowerUp(col.gameObject.tag);
			Destroy (col.gameObject);
		}
    }
}
