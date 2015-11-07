using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject explosion;

    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    private HealthBar healthBar;

    void Start()
    {
        healthBar = GameObject.Find("health").GetComponent<HealthBar>();
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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        var v3Pos = ray.GetPoint(dist);
        v3Pos = PowerUpManager.IsReverse ? -v3Pos : v3Pos;
        transform.position = v3Pos + v3Offset;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
            HandleCollisionWithEnemy(col);
        else
            HandleCollisionWithPowerup(col);
    }

    private void HandleCollisionWithEnemy(Collision2D col)
    {
        if (PowerUpManager.IsInvincible)
            Destroy(col.gameObject);
        else
            HandlePlayerHit();
    }

    private void HandlePlayerHit()
    {
        healthBar.SubHealth();
        if (!healthBar.IsDead()) return;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private static void HandleCollisionWithPowerup(Collision2D col)
    {
        PowerUpManager.SetPowerUp(col.gameObject.tag);
        Destroy(col.gameObject);
    }
}
