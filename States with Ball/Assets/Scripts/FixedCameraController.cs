using UnityEngine;
using System.Collections;

public class FixedCameraController : MonoBehaviour 
{
	private Vector3 offset;
	
	// Use this for initialization
	void Start () 
	{
		offset = transform.position;
	}
}
