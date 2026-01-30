namespace AurynSky.ForestPack
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

	
	public Vector3 rotateDirection;
	public float rotateSpeed;
	public bool isRotating;

	
	void Update () 
	{
		if(isRotating)
		{
			transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
		}
		
	}
}
}