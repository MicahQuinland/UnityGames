using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
		GameObject player; // This had to be added for added music, seems like ways to work around
		GameObject crates;
		//public GameManager gms;
		//GameObject gm;
		public Text countBlocks;
		public Text winText;
		public Text newInfo;
		public int nBlocks;
		public int sceneNum;
		public Text gTime;
		public int sTime;

		void Start()
		{
			//gm = GameObject.Find ("GameManager");
			crates = GameObject.Find ("TheBlocks");
			//nBlocks = 10;
			//sceneNum = 1;
			//sTime = 120000;
		    SetNewTime ();
			SetBlockText ();
			winText.text = "";
			newInfo.text = "";

			if (sceneNum == 1)
			{
				winText.text = "Push crates";
				newInfo.text = "off screen to the right";
			}

		}

		void Awake()
		{
			//DontDestroyOnLoad (transform.gameObject);
		}

		public void quitgame()
		{
			Application.Quit();
		}

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
				player = other.gameObject;
				AudioSource audio = player.GetComponent<AudioSource> ();
				audio.Play ();
				YouLose ();
                //SceneManager.LoadScene(1); use this if you don't want a wait
            }

			else if (other.tag == "Block")
			{
				//GameManager.SP.block ();
				nBlocks--;
				SetBlockText ();
				//crates = other.gameObject;
				AudioSource audio2 = crates.GetComponent<AudioSource> ();
				audio2.Play ();
			}
        }
			
		IEnumerator wait() //This is code routine for wait
		{
			if (sceneNum == 1) {
				yield return new WaitForSeconds (2);
			} else {
				yield return new WaitForSeconds (4);
			}

				SceneManager.LoadScene (sceneNum);
		}

		void Update () {
			sTime -= (int) Time.time;
			SetNewTime ();
			if (sTime < 0)
			{
				YouLose ();
			}

			if (sTime < 299000 && sceneNum == 1 && sTime > 298500)
			{
				winText.text = "";
				newInfo.text = "";
			}
		}

		void YouLose()
		{
			sceneNum = 0;
			winText.text = "YOU LOSE!";
			newInfo.text = "Play Again";
			StartCoroutine ("wait");
		}

		void SetNewTime()
		{
			gTime.text = "Time: " + sTime.ToString () + " ms";
		}

		void SetBlockText()
		{
			countBlocks.text = "Block Count: " + nBlocks.ToString ();
			if (nBlocks == 0)
			{
				if (sceneNum == 1) {
					winText.text = "YOU WIN!";
					newInfo.text = "Faster, more crates!";
					StartCoroutine ("wait");
				} 
				else if(sceneNum == 2) {
					winText.text = "YOU WIN!";
					newInfo.text = "Remember where they are?";
					StartCoroutine ("wait");
				}
				else 
				{
					winText.text = "YOU WIN!";
					newInfo.text = "Play Again!";
					StartCoroutine ("wait");
				}

			}
		}
    }
}
