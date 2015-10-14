using UnityEngine;
using System.Collections;

public class ballMover : MonoBehaviour {

    public GameObject explosion;
    Vector3 velocity;

    private float dist;
    private Vector3 v3Offset;
    private Plane plane;

    void OnMouseDown()
    {
        plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        v3Offset = transform.position - ray.GetPoint(dist);
    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        Vector3 v3Pos = ray.GetPoint(dist);
        transform.position = v3Pos + v3Offset;
    }


    // Use this for initialization
    void Start () {
        velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        float step = .08F;

        if (Input.GetKey("left")){
            transform.position += new Vector3(-step, 0, 0);
        }
        if (Input.GetKey("right")){
            transform.position += new Vector3(step, 0, 0);
        }
        if (Input.GetKey("up")){
            transform.position += new Vector3(0, step, 0);
        }
        if (Input.GetKey("down")){
            transform.position += new Vector3(0, -step, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
