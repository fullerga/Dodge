using UnityEngine;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class EnemyControllerTest : MonoBehaviour
{
    GameObject GameObject;
    EnemyController Controller;
    const float DeltaTime = 1F;

    [SetUp]
    public void Before()
    {
        GameObject = new GameObject();
        var movement = Substitute.For<EnemyMovement>();
        movement.PositionTransform(Arg.Any<EnemyPosition>(), DeltaTime).ReturnsForAnyArgs(Vector3.one);
        movement.RotationTransform(Arg.Any<EnemyPosition>(), DeltaTime).ReturnsForAnyArgs(Quaternion.identity);
        Controller = new EnemyController(movement, new RandomSpawner(), new HealthBar());
    }

    [TearDown]
    public void After()
    {
        DestroyImmediate(GameObject);
    }

    [Test]
    public void NoPowerUpActivesDoesNotAffectEnemySpeed()
    {
        NoPowerupActive();
        Controller.Update(GameObject, DeltaTime);
        Assert.AreEqual(GameObject.transform.position, Vector3.one);
    }

    [Test]
    public void SlowPowerUpActiveSlowsEnemySpeed()
    {
        SlowPowerupActive();
        Controller.Update(GameObject, DeltaTime);
        Assert.AreEqual(GameObject.transform.position, Vector3.one * EnemyController.SlowMultiplier);
    }

    [Test]
    public void FastPowerUpActiveMakesEnemySpeedFaster()
    {
        FastPowerupActive();
        Controller.Update(GameObject, DeltaTime);
        Assert.AreEqual(GameObject.transform.position, Vector3.one * EnemyController.FastMultiplier);
    }

    [Test]
    public void EnemiesAreDestroyedWhenTheyAreOutOfView()
    {
        GameObject.transform.position = new Vector3(WorldCoordinates.LargestDimension, WorldCoordinates.LargestDimension, 1);
        Controller.Update(GameObject, DeltaTime);
        Assert.IsTrue(GameObject == null);
        // Assert.IsNull(GameObject) does'nt work for some reason....
    }

    void NoPowerupActive()
    {
        PowerUpManager.IsFast = false;
        PowerUpManager.IsSlow = false;
    }

    void SlowPowerupActive()
    {
        PowerUpManager.IsFast = false;
        PowerUpManager.IsSlow = true;
    }

    void FastPowerupActive()
    {
        PowerUpManager.IsFast = true;
        PowerUpManager.IsSlow = false;
    }
}