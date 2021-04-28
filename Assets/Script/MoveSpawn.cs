using UnityEngine;
using System.Collections;

public class MoveSpawn : MonoBehaviour {
	public float Limite;
	public float speed = 5;
	public SpriteRenderer ActualPose;
	//
	public Sprite PosePrendi;
	public Sprite PoseTieni;
	public Sprite PoseLascia;
	//
	bool fermo = false;
	int Right = 1;
	// Use this for initialization
	void Start () 
	{
		ActualPose.sprite = PoseTieni;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!AttributiPlayer.MORTE) 
		{
			if (transform.position.x > Limite) {
				Right = -1;
			}
			if (transform.position.x < -Limite) {
				Right = 1;
			}
			if (!fermo) {
				transform.position += Vector3.right * Time.deltaTime * speed * Right;
			}
		}
		else
		{
			//CancelInvoke("Abbassati");
			//CancelInvoke("PrendiOggetto");
		}
	}

	public void FermaStrega()
	{
		fermo = true;
		ActualPose.sprite = PoseLascia;
		Invoke ("Abbassati",0.5f);
	}

	void Abbassati ()
	{
		ActualPose.sprite = PosePrendi;
		Invoke ("PrendiOggetto",0.3f);
	}

	void PrendiOggetto()
	{
		ActualPose.sprite = PoseTieni;
		fermo = false;
	}
}


