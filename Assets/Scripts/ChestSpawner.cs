using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [Header("Chest Settings")]
    public GameObject chestPrefab;
    public float chestScale = 1f;
    public float yOffset = 0.5f;
    public Vector3 chestRotation = new Vector3(0f, 180f, 0f);

    [Header("Timing")]
    public float minSpawnDelay = 10f;
    public float maxSpawnDelay = 30f;
    public float chestLifetime = 30f;

    [Header("Reward")]
    public int coinReward = 100;

    private GameObject currentChest;
    private ChestPlace currentPlace;

    void Start()
    {
        Debug.Log("ChestSpawner indult! ChestPlace-ek: " + ChestPlace.AllPlaces.Count);
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(waitTime);

            if (currentChest == null)
            {
                SpawnChest();
            }
        }
    }

    void SpawnChest()
    {
        if (chestPrefab == null) return;

        List<ChestPlace> emptyPlaces = new List<ChestPlace>();

        foreach (ChestPlace place in ChestPlace.AllPlaces)
        {
            if (!place.hasChest)
            {
                emptyPlaces.Add(place);
            }
        }

        if (emptyPlaces.Count == 0)
        {
            Debug.Log("Nincs ures ChestPlace!");
            return;
        }

        currentPlace = emptyPlaces[Random.Range(0, emptyPlaces.Count)];
        currentPlace.hasChest = true;

        Vector3 spawnPos = currentPlace.transform.position + new Vector3(0, yOffset, 0);
        Quaternion spawnRot = Quaternion.Euler(chestRotation);

        currentChest = Instantiate(chestPrefab, spawnPos, spawnRot);
        currentChest.transform.localScale = Vector3.one * chestScale;

        TreasureChest chestScript = currentChest.GetComponent<TreasureChest>();
        if (chestScript != null)
        {
            chestScript.Initialize(coinReward, chestLifetime, this, currentPlace);
        }

        Debug.Log("Chest megjelent: " + currentPlace.name);
    }

    public void ResetHighlight(ChestPlace place)
    {
        if (place != null)
        {
            place.hasChest = false;
        }
        currentPlace = null;
    }
}