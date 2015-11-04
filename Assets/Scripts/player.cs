using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public GameObject explosion;

    private float dist;
    private Vector3 v3Offset;
    private Plane plane;

    healthBar hb;

    void Start ()
    {
        hb = GameObject.Find("health").GetComponent<healthBar>();
    }


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
        if (col.gameObject.tag == "enemy")
        {
            hb.subHealth();
            if (hb.isDead())
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
