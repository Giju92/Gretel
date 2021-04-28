using UnityEngine;
using System.Collections;

public class NuovaPartita : MonoBehaviour {
	public AttributiPlayer script;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame ()
	{
		script.RisettaVariabili ();
		AttributiPlayer.MORTE = false;
	}
}
