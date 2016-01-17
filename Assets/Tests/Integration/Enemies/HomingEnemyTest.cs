using UnityEngine;

public class HomingEnemyTest : MonoBehaviour
{
    // TODO finish this test after moving health to the player so a healthbar isn't needed for the test scene
    public GameObject HomingEnemy;
    public GameObject Player;

    Vector3 PlayerPostion;

    void Start()
    {
        if (Player == null)
            IntegrationTest.Fail(HomingEnemy);
        PlayerPostion = Player.transform.position;
    }

    void Update()
    {
        if (HomingEnemy.transform.position.Equals(PlayerPostion))
            IntegrationTest.Pass(HomingEnemy);
    }
}
