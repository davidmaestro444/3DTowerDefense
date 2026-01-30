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
        while (!GameManager.Instance.isGameEnded)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        Transform[] chosenPath = GetRandomPath();

        GameObject enemyPrefab = ChooseEnemyType();

        if (enemyPrefab == null)
        {
            Debug.LogError("Nincs enemy prefab beallitva!");
            return;
        }

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
        var availableEnemies = new System.Collections.Generic.List<GameObject>();

        if (soldierPrefab != null)
            availableEnemies.Add(soldierPrefab);

        if (wizardUnlocked && wizardPrefab != null)
            availableEnemies.Add(wizardPrefab);

        if (gruntUnlocked && gruntPrefab != null)
            availableEnemies.Add(gruntPrefab);

        if (golemUnlocked && golemPrefab != null)
            availableEnemies.Add(golemPrefab);

        if (availableEnemies.Count > 0)
        {
            return availableEnemies[Random.Range(0, availableEnemies.Count)];
        }

        return soldierPrefab;
    }

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
                if (golemKills >= 5)
                {
                    GameManager.Instance.WinGame();
                }
                break;
        }
    }
}