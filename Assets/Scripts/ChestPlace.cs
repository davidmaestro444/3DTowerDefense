using System.Collections.Generic;
using UnityEngine;

public class ChestPlace : MonoBehaviour
{
    public static List<ChestPlace> AllPlaces = new List<ChestPlace>();

    public bool hasChest = false;

    void OnEnable()
    {
        AllPlaces.Add(this);
    }

    void OnDisable()
    {
        AllPlaces.Remove(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 0.5f, 1f));
        Gizmos.DrawIcon(transform.position, "d_Favorite Icon", true);
    }
}