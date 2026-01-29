using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [Header("Enemy Prefabs")]
    public GameObject soldierPrefab;
    public GameObject wizardPrefab;
    public GameObject gruntPrefab;
    public GameObject golemPrefab;

    [Header("Paths")]
    public Transform[] pathA;
    public Transform[] pathB;
    public Transform[] pathC;

    [Header("Timing")]
    public float timeBetweenWaves = 2f;

    [Header("Unlock Progress - NE ALLITSD KEZZEL")]
    public int soldierKills = 0;
    public int wizardKills = 0;
    public int gruntKills = 0;
    public int golemKills = 0;

    [Header("Kills Required")]
    public int killsToUnlockWizard = 10;
    public int killsToUnlockGrunt = 10;
    public int killsToUnlockGolem = 10;

    // Melyik enemy tipusok aktívak
    private bool wizardUnlocked = false;
    private bool gruntUnlocked = false;
    private bool golemUnlocked = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        // Utvonal valasztasa
        Transform[] chosenPath = GetRandomPath();

        // Enemy tipus valasztasa
        GameObject enemyPrefab = ChooseEnemyType();

        if (enemyPrefab == null)
        {
            Debug.LogError("Nincs enemy prefab beallitva!");
            return;
        }

        // Spawn
        GameObject newEnemy = Instantiate(enemyPrefab, chosenPath[0].position, Quaternion.identity);
        EnemyMovement movement = newEnemy.GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.waypoints = chosenPath;
        }
    }

    Transform[] GetRandomPath()
    {
        int randomChoice = Random.Range(0, 3);

        if (randomChoice == 0)
            return pathA;
        else if (randomChoice == 1)
            return pathB;
        else
            return pathC;
    }

    GameObject ChooseEnemyType()
    {
        // Osszes elerheto enemy tipus listaja
        var availableEnemies = new System.Collections.Generic.List<GameObject>();

        // Soldier mindig elerheto
        if (soldierPrefab != null)
            availableEnemies.Add(soldierPrefab);

        // Wizard ha unlock-olva
        if (wizardUnlocked && wizardPrefab != null)
            availableEnemies.Add(wizardPrefab);

        // Grunt ha unlock-olva
        if (gruntUnlocked && gruntPrefab != null)
            availableEnemies.Add(gruntPrefab);

        // Golem ha unlock-olva
        if (golemUnlocked && golemPrefab != null)
            availableEnemies.Add(golemPrefab);

        // Random valasztas
        if (availableEnemies.Count > 0)
        {
            return availableEnemies[Random.Range(0, availableEnemies.Count)];
        }

        return soldierPrefab;
    }

    // Ezt hivja meg az EnemyMovement amikor meghal
    public void EnemyKilled(EnemyMovement.EnemyType type)
    {
        switch (type)
        {
            case EnemyMovement.EnemyType.Soldier:
                soldierKills++;
                Debug.Log("Soldier kills: " + soldierKills + "/" + killsToUnlockWizard);
                if (soldierKills >= killsToUnlockWizard && !wizardUnlocked)
                {
                    wizardUnlocked = true;
                    Debug.Log("=== WIZARD UNLOCKED! ===");
                }
                break;

            case EnemyMovement.EnemyType.Wizard:
                wizardKills++;
                Debug.Log("Wizard kills: " + wizardKills + "/" + killsToUnlockGrunt);
                if (wizardKills >= killsToUnlockGrunt && !gruntUnlocked)
                {
                    gruntUnlocked = true;
                    Debug.Log("=== GRUNT UNLOCKED! ===");
                }
                break;

            case EnemyMovement.EnemyType.Grunt:
                gruntKills++;
                Debug.Log("Grunt kills: " + gruntKills + "/" + killsToUnlockGolem);
                if (gruntKills >= killsToUnlockGolem && !golemUnlocked)
                {
                    golemUnlocked = true;
                    Debug.Log("=== GOLEM UNLOCKED! ===");
                }
                break;

            case EnemyMovement.EnemyType.Golem:
                golemKills++;
                Debug.Log("Golem kills: " + golemKills);
                break;
        }
    }
}