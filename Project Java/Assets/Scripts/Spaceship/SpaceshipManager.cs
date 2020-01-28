using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpaceshipManager : MonoBehaviour
{
    [SerializeField]
    private Spaceship[] spaceships;
    public float spaceshipMinSpawnRange = 500f;
    public int maxSpaceshipsSpawn = 15;
    public float spawnSpaceshipDelay = 20f;

    private static SpaceshipManager singleton = null;
    private List<Spaceship> spaceshipSpawned = new List<Spaceship>();

    private void Start()
    {
        if (singleton == null)
            singleton = this;

        for (int i = 0; i < maxSpaceshipsSpawn; i++)
            SpawnSpaceship();

        InvokeRepeating("SpawnSpaceship", 0, spawnSpaceshipDelay);
    }

    private void ClearSpaceshipSpawned()
    {
        spaceshipSpawned.RemoveAll(spaceship => spaceship == null);
    }

    private void SpawnSpaceship()
    {
        ClearSpaceshipSpawned();
        if (this.spaceshipSpawned.Count >= maxSpaceshipsSpawn)
            return;

        ClearSpaceshipSpawned();

        int nbAlliesSpawned = this.spaceshipSpawned.FindAll(spaceship => spaceship is Allied).Count;
        int nbEnemiesSpawned = this.spaceshipSpawned.FindAll(spaceship => spaceship is Enemy).Count;

        var spaceshipsFound = spaceships.ToList().FindAll(
                spaceship => 
                {
                    if (nbEnemiesSpawned > nbAlliesSpawned && nbEnemiesSpawned > 0) { return spaceship is Allied; }
                    else { return spaceship is Enemy; }
                }
            );

        int nb = Random.Range(0, spaceshipsFound.Count);
        Vector3 pos = Random.insideUnitSphere * spaceshipMinSpawnRange;
        var spaceshipSpawned = Instantiate(spaceshipsFound[nb], Player.player.transform.position + pos, Quaternion.identity);

        this.spaceshipSpawned.Add(spaceshipSpawned);
        SetSpaceshipTarget(spaceshipSpawned);
    }

    public static void SetSpaceshipTarget(Spaceship newSpaceship)
    {
        singleton.ClearSpaceshipSpawned();
        if (newSpaceship is Enemy)
        {
            var alliesSpaceship = singleton.spaceshipSpawned.FindAll(spaceship => spaceship is Allied);
            if (alliesSpaceship.Count == 0)
            {
                newSpaceship.SetTarget(Player.player.transform);
            }
            else
            {
                bool aggroPlayer = Random.Range(0f, 1f) >= 0.7f;
                Transform target = aggroPlayer ? Player.player.transform : alliesSpaceship[Random.Range(0, alliesSpaceship.Count)].transform;
                newSpaceship.SetTarget(target);
            }
        }
        else
        {
            var enemiesSpaceships = singleton.spaceshipSpawned.FindAll(spaceship => spaceship is Enemy);
            if (enemiesSpaceships.Count != 0)
            {
                newSpaceship.SetTarget(enemiesSpaceships[Random.Range(0, enemiesSpaceships.Count)].transform);
            }
        }
    }
}
