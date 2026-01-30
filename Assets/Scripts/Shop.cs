using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint dualTurret;

    public void SelectStandardTurret()
    {
        Debug.Log("Alap torony kivalasztva");
        BuildManager.Instance.SelectTurretToBuild(standardTurret);
    }
    public void SelectDualTurret()
    {
        Debug.Log("Dupla torony kiválasztva");
        BuildManager.Instance.SelectTurretToBuild(dualTurret);
    }
}
