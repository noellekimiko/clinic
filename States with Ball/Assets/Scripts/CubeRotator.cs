﻿using UnityEngine;
using System.Collections;

public class CubeRotator : MonoBehaviour 
{
	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime); //default space value used
	}
}
