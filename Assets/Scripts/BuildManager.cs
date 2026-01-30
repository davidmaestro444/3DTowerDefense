using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public UpgradeUI upgradeUI;
    private TurretPlace selectedNode;

    void Awake()
    {
        Instance = this;
    }

    private TurretBlueprint turretToBuild;
    public bool CanBuild { get { return turretToBuild != null; } }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DeselectNode();
            turretToBuild = null;
            UpdateAllTurretPlaces(false);
        }
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
        UpdateAllTurretPlaces(true);
    }

    public void BuildTurretOn(TurretPlace place)
    {
        if (GameManager.Instance.currentCoins < turretToBuild.cost)
        {
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

    public void SelectNode(TurretPlace node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        upgradeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        upgradeUI.Hide();
    }
}

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
}
