namespace AurynSky.DesertPack
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public Vector3 direction;
	public float speed;
	
	void Update () 
	{
		transform.Rotate(direction * speed * Time.deltaTime);
	}
}
}
