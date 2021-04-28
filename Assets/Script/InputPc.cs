using UnityEngine;
using System.Collections;

public class InputPc : MonoBehaviour 
{
	public AttributiPlayer pg;
	public Rigidbody2D body;
	public float EnergiaConsumata;
	public float ForzaApplicata;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!AttributiPlayer.MORTE) 
		{
			if (Input.GetKey ("d")) 
			{
				//pg.Energia-=Time.deltaTime*EnergiaConsumata;
				body.AddForce(Vector3.right*ForzaApplicata);
			}
			if (Input.GetKey ("a")) 
			{
				//pg.Energia-=Time.deltaTime*EnergiaConsumata;
				body.AddForce(Vector3.left*ForzaApplicata);
			}
			if (Input.GetKey ("e")) 
			{
				PlayerPrefs.SetFloat("Record",0f);
			}
		}
	}
}
