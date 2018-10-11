using UnityEngine;
using System.Collections;

public class ChangeMaterials : MonoBehaviour 
{
	// pants-2 materials
	//public SkinnedMeshRenderer Pants2_smr;
	public SkinnedMeshRenderer[] Apparel;
	// ? public int[] mlist;
	public Material[] hair;
	public Material[] face;
	public Material[] eyes;
	public Material[] top;
	public Material[] pants;
	public Material[] shoes;
	public int current_app;
	private int hair_mat = 0;
	private int face_mat = 0;
	private int eyes_mat = 0;
	private int top_mat = 0;
	private int pants_mat = 0;
	private int shoes_mat = 0;

	// Use this for initialization
	void Start () 
	{	
		Apparel[0].material = hair [hair_mat];
		Apparel[1].material = hair [hair_mat];
		Apparel[2].material = face [face_mat];
		Apparel[3].material = face [face_mat];
		Apparel[4].material = eyes [eyes_mat];
		Apparel[5].material = top  [top_mat];
		Apparel[6].material = top  [top_mat];
		Apparel[7].material = pants [pants_mat];
		Apparel[8].material = pants [pants_mat];
		Apparel[9].material = shoes [shoes_mat];
		Apparel[10].material = shoes [shoes_mat];

		current_app = 0;
	}

	public void chair(){

		current_app = 0;
	}

	public void cface(){

		current_app = 2;
	}

	public void ceyes(){

		current_app = 4;
	}

	public void ctop(){

		current_app = 5;
	}

	public void cpants(){

		current_app = 7;
	}

	public void cshoes(){

		current_app = 9;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			switch(current_app){

			case 0:
				++hair_mat;
				if (hair_mat >= hair.Length)
					hair_mat = 0;
				Apparel [current_app].material = hair [hair_mat];
				current_app++;
				Apparel[current_app].material = hair [hair_mat];
				current_app--;
				break;
			case 2:
				++face_mat;
				if (face_mat >= face.Length)
					face_mat = 0;
				Apparel[current_app].material = face [face_mat];
				current_app++;
				Apparel[current_app].material = face [face_mat];
				current_app--;
				break;
			case 4:
				++eyes_mat;
				if (eyes_mat >= eyes.Length)
					eyes_mat = 0;
				Apparel[current_app].material = eyes [eyes_mat];
				break;
			case 5:
				++top_mat;
				if (top_mat >= top.Length)
					top_mat = 0;
				Apparel[current_app].material = top [top_mat];
				current_app++;
				Apparel[current_app].material = top [top_mat];
				current_app--;
				break;
			case 7:
				++pants_mat;
				if (pants_mat >= pants.Length)
					pants_mat = 0;
				Apparel[current_app].material = pants [pants_mat];
				current_app++;
				Apparel[current_app].material = pants [pants_mat];
				current_app--;
				break;
			case 9:
				++shoes_mat;
				if (shoes_mat >= shoes.Length)
					shoes_mat = 0;
				Apparel[current_app].material = shoes [shoes_mat];
				current_app++;
				Apparel[current_app].material = shoes [shoes_mat];
				current_app--;
				break;
			}
			
		}

		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			switch(current_app){

			case 0:
				--hair_mat;
				if (hair_mat <= 0)
					hair_mat = hair.Length;
				Apparel[current_app].material = hair [hair_mat];
				current_app++;
				Apparel[current_app].material = hair [hair_mat];
				current_app--;
				break;
			case 2:
				--face_mat;
				if (face_mat <= 0)
					face_mat = face.Length;
				Apparel[current_app].material = face [face_mat];
				current_app++;
				Apparel[current_app].material = face [face_mat];
				current_app--;
				break;
			case 4:
				--eyes_mat;
				if (eyes_mat <= 0)
					eyes_mat = eyes.Length;
				Apparel[current_app].material = eyes [eyes_mat];
				break;
			case 5:
				--top_mat;
				if (top_mat <= 0)
					top_mat = top.Length;
				Apparel[current_app].material = top [top_mat];
				current_app++;
				Apparel[current_app].material = top [top_mat];
				current_app--;
				break;
			case 7:
				--pants_mat;
				if (pants_mat <= 0)
					pants_mat = pants.Length;
				Apparel[current_app].material = pants [pants_mat];
				current_app++;
				Apparel[current_app].material = pants [pants_mat];
				current_app--;
				break;
			case 9:
				--shoes_mat;
				if (shoes_mat <= 0)
					shoes_mat = shoes.Length;
				Apparel[current_app].material = shoes [shoes_mat];
				current_app++;
				Apparel[current_app].material = shoes [shoes_mat];
				current_app--;
				break;

			}

		}
	
	}
}
