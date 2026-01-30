using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretPlace : MonoBehaviour
{
    public static List<TurretPlace> AllPlaces = new List<TurretPlace>();

    private void Awake()
    {
        AllPlaces.Add(this);
    }
    private void OnDestroy()
    {
        AllPlaces.Remove(this);
    }

    public Color hoverColor;
    public Color readyColor;
    private Color startColor;
    private Renderer rend;
    public GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void SetHighlight(bool active)
    {
        if (turret != null) return;

        if (active)
        {
            rend.material.color = readyColor;
        }
        else
        {
            rend.material.color = startColor;
        }
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (turret != null)
        {
            BuildManager.Instance.SelectNode(this);
            return;
        }
        if (!BuildManager.Instance.CanBuild) return;
        if (turret != null) return;

        BuildManager.Instance.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!BuildManager.Instance.CanBuild) return;
        if (turret != null) return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (BuildManager.Instance.CanBuild && turret == null)
        {
            rend.material.color = readyColor;
        }
        else
        {
            rend.material.color = startColor;
        }
    }
}
