using UnityEngine;
using System.Collections;

public class SpawnOggetti : MonoBehaviour {
	public Transform SpawnPoint;
	public GameObject[] Cibo;
	public float SpawnTime;
	public float RangeTime;
	public float MoltiplicatoreDifficolta = 3;//percentuale
	//
	public MoveSpawn strega;
	GameObject Obj;
	float spawnTime = 0;
	float waitTime = 0;
	public AttributiPlayer pg;
	// Use this for initialization
	void Start () 
	{
		//ResettaContatore ();
		Invoke ("SpawnCibo",0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (AttributiPlayer.MORTE) 
		{
			//CancelInvoke("FaCadere");
		}
	}

	void ResettaContatore ()
	{
		if (!AttributiPlayer.MORTE) 
		{
			CancelInvoke("SpawnCibo");
		}
		//if (!AttributiPlayer.MORTE) 
		{
			spawnTime = SpawnTime + Random.Range (-RangeTime, RangeTime);
			//Debug.Log ("spawnTime="+spawnTime);
			Invoke ("FaCadere", spawnTime);
		}
	}
	void SpawnCibo ()
	{
		GameObject CiboDaSpawnare = Cibo [Random.Range (0, Cibo.Length)];
		Obj = Instantiate (CiboDaSpawnare, SpawnPoint.position, Quaternion.identity) as GameObject;
		Obj.transform.parent = strega.transform;
		Obj.transform.localPosition = new Vector3 (-0.26f,-0.2f,0);

		AumentaDifficolta ();
		if (!AttributiPlayer.MORTE) 
		{
			ResettaContatore ();
		}
	}

	void AumentaDifficolta ()
	{
		SpawnTime -= (SpawnTime / 100f) * MoltiplicatoreDifficolta;
		RangeTime -= (RangeTime / 100f) * MoltiplicatoreDifficolta;
		pg.EnergiaPersaSec += (pg.EnergiaPersaSec / 100f) * MoltiplicatoreDifficolta;
		pg.AttributiPersi += (pg.AttributiPersi / 100f) * MoltiplicatoreDifficolta;
	}

	void FaCadere()
	{
		if(Obj!=null)
		{
			Obj.GetComponent<Rigidbody2D> ().isKinematic = false;
			Obj.transform.parent = null;
			strega.FermaStrega ();
			waitTime = 0.8f;
		}
		Invoke ("SpawnCibo",waitTime);
	}

}
