//using UnityEngine;

//public class EnemyBehaviour : MonoBehaviour
//{
//    public HealthBar hb;
//    public Spawner spawner;
//    public EnemyMovement EnemyMovement;

//    EnemyController EnemyController;

//    void Start()
//    {
//        EnemyController = new EnemyController(EnemyMovement);
//    }

//    void Update()
//    {
//        print(transform);
//        EnemyController.Update(transform, Time.deltaTime);
//    }

//    //private float GetSpeedMultiplier()
//    //{
//    //    if (PowerUpManager.IsSlow)
//    //        return 0.5F;
//    //    if (PowerUpManager.IsFast)
//    //        return 2F;
//    //    return 1F;
//    //}

//    //protected bool IsOutOfView()
//    //{
//    //    return transform.position.x > WorldCoordinates.LargestDimension || transform.position.x < -WorldCoordinates.LargestDimension
//    //        || transform.position.y > WorldCoordinates.LargestDimension || transform.position.y < -WorldCoordinates.LargestDimension;
//    //}

//    //protected void DestroyEnemy()
//    //{
//    //    Destroy(gameObject);
//    //    spawner.EnemyDied();
//    //    if (!hb.IsDead())
//    //        gameStats.points++;
//    //}
//}
