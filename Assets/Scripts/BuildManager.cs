using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    void Awake()
    {
        Instance = this;
    }

    private TurretBlueprint turretToBuild;
    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        UpdateAllTurretPlaces(true);
    }

    public void BuildTurretOn(TurretPlace place)
    {
        if (GameManager.Instance.currentCoins < turretToBuild.cost)
        {
            Debug.Log("Nincs eleg penz!");
            return;
        }

        GameManager.Instance.SpendCoins(turretToBuild.cost);

        GameObject turret = Instantiate(turretToBuild.prefab, place.transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
        place.turret = turret;
        turretToBuild = null;
        UpdateAllTurretPlaces(false);
    }

    void UpdateAllTurretPlaces(bool active)
    {
        foreach (TurretPlace place in TurretPlace.AllPlaces)
        {
            place.SetHighlight(active);
        }
    }
}

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
}
