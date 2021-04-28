using UnityEngine;
using System.Collections;

public class TriggerGabbia : MonoBehaviour {
	public AttributiPlayer Pg;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D Obj)
	{
		Debug.Log ("Collision with: "+Obj.name);
		//_________________
		if (Obj.name=="Apple(Clone)") 
		{
			Pg.Energia += 72;
			Pg.Proteine += 0.3f;
			Pg.Grassi += 0.2f;
			Pg.Carboidrati += 19;
		}
		//__________________
		if (Obj.name=="Aubergine(Clone)") 
		{
			Pg.Energia += 25;
			Pg.Proteine += 1;
			Pg.Grassi += 0.2f;
			Pg.Carboidrati += 6;
		}
		//__________________
		if (Obj.name=="Cake(Clone)") 
		{
			Pg.Energia += 235;
			Pg.Proteine += 3;
			Pg.Grassi += 10;
			Pg.Carboidrati += 35;
		}
		//__________________
		if (Obj.name=="Cheese(Clone)") 
		{
			Pg.Energia += 98;
			Pg.Proteine += 7;
			Pg.Grassi += 7.5f;
			Pg.Carboidrati += 0.6f;
		}
		//__________________
		if (Obj.name=="Chicken(Clone)") 
		{
			Pg.Energia += 147;
			Pg.Proteine += 16;
			Pg.Grassi += 8;
			Pg.Carboidrati += 0;
		}
		//__________________
		if (Obj.name=="Cola(Clone)") 
		{
			Pg.Energia += 132;
			Pg.Proteine += 0;
			Pg.Grassi += 0;
			Pg.Carboidrati += 33;
		}
		//__________________
		if (Obj.name=="Egg(Clone)") 
		{
			Pg.Energia += 92;
			Pg.Proteine += 6;
			Pg.Grassi += 7;
			Pg.Carboidrati += 0.5f;
		}
		//__________________
		if (Obj.name=="Fish(Clone)") 
		{
			Pg.Energia += 142;
			Pg.Proteine += 24;
			Pg.Grassi += 4;
			Pg.Carboidrati += 0;
		}
		//__________________
		if (Obj.name=="Hamburger(Clone)") 
		{
			Pg.Energia += 272;
			Pg.Proteine += 12;
			Pg.Grassi += 10;
			Pg.Carboidrati += 34;
		}
		//__________________
		/*if (Obj.name=="Lemon(Clone)") 
		{
			Pg.Energia += 11;
			Pg.Proteine += 0;
			Pg.Grassi += 0;
			Pg.Carboidrati += 1;
		}*/
		//__________________
		if (Obj.name=="Milk(Clone)") 
		{
			Pg.Energia += 146;
			Pg.Proteine += 8;
			Pg.Grassi += 8;
			Pg.Carboidrati += 11;
		}
		//__________________
		if (Obj.name=="Mushrooms(Clone)") 
		{
			Pg.Energia += 25;
			Pg.Proteine += 2;
			Pg.Grassi += 0.3f;
			Pg.Carboidrati += 5;
		}
		//__________________
		if (Obj.name=="Pear(Clone)") 
		{
			Pg.Energia += 96;
			Pg.Proteine += 0.6f;
			Pg.Grassi += 0.2f;
			Pg.Carboidrati += 25;
		}
		//__________________
		if (Obj.name=="Pepper(Clone)") 
		{
			Pg.Energia += 50;
			Pg.Proteine += 2;
			Pg.Grassi += 0.4f;
			Pg.Carboidrati += 12;
		}
		//__________________
		if (Obj.name=="Pizza(Clone)") 
		{
			Pg.Energia += 265;
			Pg.Proteine += 10;
			Pg.Grassi += 12;
			Pg.Carboidrati += 28;
		}
		//__________________
		if (Obj.name=="Sweet(Clone)") 
		{
			Pg.Energia += 24;
			Pg.Proteine += 0;
			Pg.Grassi += 0;
			Pg.Carboidrati += 6;
		}
		Destroy (Obj.gameObject,0.05f);
	}
}
