using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

    public void SelectStandardTurret()
    {
        Debug.Log("Alap torony kivalasztva");
        BuildManager.Instance.SelectTurretToBuild(standardTurret);
    }
}
