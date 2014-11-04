using UnityEngine;
using System.Collections;

public class CoinRotator : MonoBehaviour {
	
	void Update () 
	{
		transform.Rotate (new Vector3 (45, 0, 0) * Time.deltaTime); //default space value used
	}
}
