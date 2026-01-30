using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject uiCanvas;
    public TextMeshProUGUI upgradeCostText;
    public Button upgradeButton;

    private TurretPlace target;

    public void SetTarget(TurretPlace _target)
    {
        target = _target;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        screenPos.y += 50f;
        transform.position = screenPos;
        Turret turretScript = target.turret.GetComponent<Turret>();

        if (!turretScript.isUpgraded)
        {
            upgradeCostText.text = "UPGRADE\n$" + turretScript.upgradeCost;
            upgradeButton.interactable = (GameManager.Instance.currentCoins >= turretScript.upgradeCost);
        }
        else
        {
            upgradeCostText.text = "MAX LEVEL";
            upgradeButton.interactable = false;
        }
        uiCanvas.SetActive(true);
    }

    public void Hide()
    {
        uiCanvas.SetActive(false);
    }

    public void Upgrade()
    {
        Turret turretScript = target.turret.GetComponent<Turret>();
        if (GameManager.Instance.currentCoins < turretScript.upgradeCost) return;
        GameManager.Instance.SpendCoins(turretScript.upgradeCost);
        turretScript.UpgradeTurret();
        BuildManager.Instance.DeselectNode();
    }
}
