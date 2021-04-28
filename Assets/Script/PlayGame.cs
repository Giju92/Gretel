using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {
	public UnityEngine.UI.Image ImgIniziale;
	public Sprite[] imgSuggerimento;
	public UnityEngine.UI.Image img;
	public GameObject game;
	public GameObject PagSuggerimento;
	public UnityEngine.UI.Text Tap;
	float cont = 0f;
	bool CanTap = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CanTap) 
		{
			cont+=Time.deltaTime;
			Tap.color=new Vector4(1,1,1,cont);
		}
	}

	public void Gioca ()
	{
		ImgIniziale.gameObject.SetActive (false);
		//AttributiPlayer.MORTE = false;
		img.sprite = imgSuggerimento [Random.Range (0, imgSuggerimento.Length)];
		Invoke ("TapEnabled",2f);

	}

	public void TapEnabled ()
	{
		CanTap = true;
	}

	public void IniziaGioco ()
	{
		if (CanTap == true) 
		{
			PagSuggerimento.SetActive (false);
			game.SetActive (true);
		}
	}
}
