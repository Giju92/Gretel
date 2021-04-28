using UnityEngine;
using System.Collections;
using System;
public class ChainOrientation : MonoBehaviour {
	public Transform ChainBack;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		double radianti = Math.Atan ((double)(transform.position.y-ChainBack.position.y) / (double)transform.position.x-ChainBack.position.x);
		double gradi = 180.0 * radianti / Math.PI;
		
		//Debug.Log(radianti);
		//Debug.Log(gradi);
		
		transform.rotation = Quaternion.Euler (0,0,(float)gradi-90);
	}
}
