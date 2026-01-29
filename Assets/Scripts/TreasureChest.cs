using System.Collections;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    private int coinReward;
    private float lifetime;
    private bool isCollected = false;
    private ChestSpawner spawner;
    private ChestPlace place;

    public void Initialize(int reward, float time, ChestSpawner chestSpawner, ChestPlace chestPlace)
    {
        coinReward = reward;
        lifetime = time;
        spawner = chestSpawner;
        place = chestPlace;

        StartCoroutine(LifetimeCountdown());
    }

    IEnumerator LifetimeCountdown()
    {
        yield return new WaitForSeconds(lifetime);

        if (!isCollected)
        {
            Debug.Log("Chest eltunt!");
            CleanUp();
        }
    }

    void OnMouseDown()
    {
        if (isCollected) return;

        isCollected = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoins(coinReward);
            Debug.Log("Chest felveve! +" + coinReward + " coin!");
        }

        CleanUp();
    }

    void CleanUp()
    {
        if (spawner != null)
        {
            spawner.ResetHighlight(place);
        }

        Destroy(gameObject);
    }
}