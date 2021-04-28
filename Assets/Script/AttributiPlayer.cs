using UnityEngine;
using System.Collections;

public class AttributiPlayer : MonoBehaviour 
{
	public static bool MORTE = false;
	public float EnergiaMax;
	public float ProteineMax;
	public float GrassiMax;
	public float CarboidratiMax;
	//
	public float Energia;
	public float Proteine;
	public float Grassi;
	public float Carboidrati;
	//
	public float EnergiaPersaSec;//da 0 a 1
	public float AttributiPersi;//da 0 a 1
	//public float ProteinePersaSec;
	//public float GrassiPersaSec;
	//public float CarboidratiPersaSec;
	//
	public UnityEngine.UI.Image EnergiaBar;
	public UnityEngine.UI.Image ProteineBar;
	public UnityEngine.UI.Image GrassiBar;
	public UnityEngine.UI.Image CarboidratiBar;
	//
	public UnityEngine.UI.Text PunteggioText;
	public UnityEngine.UI.Text PunteggioRecordText;
	public UnityEngine.UI.Text SuggerminetoText;
	public UnityEngine.UI.Image RecordImg;
	//
	public SpriteRenderer BodyHansel;
	public Sprite fat2;
	public Sprite fat1;
	public Sprite fat0;
	public Sprite normal;
	public Sprite thin0;
	public Sprite thin1;
	//
	public SpriteRenderer HeadHansel;
	public Sprite headFelice;
	public Sprite headMorto;
	public Sprite headSpaventata;
	public Sprite headGonfia;
	public Sprite headVomito;
	//
	public AudioSource Strega;
	float RecordAttuale = 0;
	//
	public float tempoTrascorso;
	public GameObject MorteBg;
	// Use this for initialization
	void Start () 
	{
		RecordAttuale=PlayerPrefs.GetFloat ("Record");
	}
	
	// Update is called once per frame
	void Update () 
	{
		AggiornaBarre ();
		AggiornaHansel ();
		if (!MORTE) 
		{
			tempoTrascorso += Time.deltaTime;
			Energia -= EnergiaPersaSec * Time.deltaTime * EnergiaMax;
			Proteine -= AttributiPersi * Time.deltaTime * ProteineMax;
			Grassi -= AttributiPersi * Time.deltaTime * GrassiMax;
			Carboidrati -= AttributiPersi * Time.deltaTime * CarboidratiMax;
			ControlloMorte ();
		}

	}

	void AggiornaHansel()
	{
		if (EnergiaBar.fillAmount < 0.2f) {BodyHansel.sprite=thin1;}
		if (EnergiaBar.fillAmount > 0.2f && EnergiaBar.fillAmount < 0.4f) {BodyHansel.sprite=thin0;}
		if (EnergiaBar.fillAmount > 0.4f && EnergiaBar.fillAmount < 0.6f) {BodyHansel.sprite=normal;}
		if (EnergiaBar.fillAmount > 0.6f && EnergiaBar.fillAmount < 0.75f) {BodyHansel.sprite=fat0;}
		if (EnergiaBar.fillAmount > 0.75f && EnergiaBar.fillAmount < 0.9f) {BodyHansel.sprite=fat1;}
		if (EnergiaBar.fillAmount > 0.9f) {BodyHansel.sprite=fat2;}
		//
		if (EnergiaBar.fillAmount < 0.2f || EnergiaBar.fillAmount > 0.8f ||
		    ProteineBar.fillAmount < 0.2f || ProteineBar.fillAmount > 0.8f ||
		    CarboidratiBar.fillAmount < 0.2f || CarboidratiBar.fillAmount > 0.8f ||
		    GrassiBar.fillAmount < 0.2f || GrassiBar.fillAmount > 0.8f) 
		{
			HeadHansel.sprite=headSpaventata;
		}
		else
		{
			HeadHansel.sprite=headFelice;
		}
	}

	void AggiornaBarre ()
	{
		EnergiaBar.fillAmount = Energia / EnergiaMax;
		ProteineBar.fillAmount = Proteine / ProteineMax;
		GrassiBar.fillAmount = Grassi / GrassiMax;
		CarboidratiBar.fillAmount = Carboidrati / CarboidratiMax;
	}

	void ControlloMorte ()
	{
		if (Energia >= EnergiaMax)	{Morte(0);}
		if (Energia <= 0)	{Morte(1);}

		if (Proteine >= ProteineMax)	{Morte(2);}
		if (Proteine <= 0)	{Morte(3);}

		if (Grassi >= GrassiMax)	{Morte(4);}
		if (Grassi <= 0)	{Morte(5);}

		if (Carboidrati >= CarboidratiMax)	{Morte(6);}
		if (Carboidrati <= 0)	{Morte(7);}
	}

	void Morte (int i)
	{
		Strega.Play ();
		MorteBg.SetActive(true);
		MORTE = true;//muahah
		Debug.Log ("sei morto");
		PunteggioRecordText.text="il tuo record: "+(int)(RecordAttuale/60f)+"m "+(int)(RecordAttuale%60)+"s";
		SuggerminetoText.text=SuggerimentoTestoMorte (i);
		//controllo record
		if (tempoTrascorso > RecordAttuale) 
		{
			RecordAttuale=tempoTrascorso;
			PlayerPrefs.SetFloat("Record",RecordAttuale);
			RecordImg.gameObject.SetActive(true);
			PunteggioRecordText.text="";
		}
		//
		PunteggioText.text=(int)(tempoTrascorso/60f)+"m "+(int)(tempoTrascorso%60)+"s";
	}

	string SuggerimentoTestoMorte (int tipoMorte)
	{
		string testo;
		switch (tipoMorte) 
		{
			case 0:
				testo="Hansel è ingrassato troppo! La strega se lo papperà per cena";
			break;
			case 1:
				testo="Hansel deve mangiare per sopravvivere! Evitare tutti gli alimenti non ti servirà";
			break;
			case 2:
				testo="hai esagerato con le proteine? forse hai mangiato troppi alimenti di origine animale";
			break;
			case 3:
				testo="sei carente di proteine! puoi trovarle nella carne";
			break;
			case 4:
				testo="troppi grassi fanno male! basta con i fast food";
			break;
			case 5:
				testo="anche i grassi sono importanti! concediti qualche dolce";
			break;
			case 6:
				testo="troppi carboidrati? la prossima volta mangia meno dolci!";
			break;
			case 7:
				testo="ti servono più carboidrati! mangia più porzioni di frutta";
			break;
			default:
				testo="";
			break;
		}
		return testo;
	}

	public void RisettaVariabili ()
	{
		Energia=EnergiaMax/2f;
		Proteine=ProteineMax/2f;
		Grassi=GrassiMax/2f;
		Carboidrati=CarboidratiMax/2f;
		tempoTrascorso = 0f;
		MorteBg.SetActive (false);
		RecordImg.gameObject.SetActive(false);
		PunteggioRecordText.text="";
		Application.LoadLevel (Application.loadedLevel);
	}
}


