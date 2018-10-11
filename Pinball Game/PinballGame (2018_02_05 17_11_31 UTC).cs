using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PinballGameState {playing, won, lost};

public class PinballGame : MonoBehaviour
{
    public static PinballGame SP;
    public Transform ballPrefab;
	public int score;
    private PinballGameState gameState;
	public int mballs = 0;
		int pfirst = 0;

	public Text winText;
	public Text scoreCount;
	public Text gTime;
	public int sTime;
	

    void Awake()
    {
        SP = this;
        gameState = PinballGameState.playing;
        Time.timeScale = 1.0f;
        SpawnBall();
		SetNewTime ();
		SetScoreText ();
		winText.text = "";
    }

	void Update () 
	{
		if(Time.timeScale == 1.0f && gameState == PinballGameState.playing){	
			sTime += (int) Time.time;
			SetNewTime ();
			}
		SetScoreText ();
	}

    void SpawnBall()
    {	
				if (score % 100 == 0 && (mballs == 1 || pfirst == 0)){
						Instantiate(ballPrefab, new Vector3(0f , 1.0f, 17f), Quaternion.identity);
						pfirst = 1;
				}
    }
		/*
    void OnGUI()
    {
    
        GUILayout.Space(10);
        GUILayout.Label("  Score: " + score.ToString());

        if (gameState == PinballGameState.lost)
        {
            GUILayout.Label("You Lost!");
            if (GUILayout.Button("Try again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else if (gameState == PinballGameState.won)
        {
            GUILayout.Label("You won!");
            if (GUILayout.Button("Play again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    } */

    public void HitBlock()
    {
		score += 10;
		SpawnBall();
    }
	
	void SetNewTime()
	{
				gTime.text = "Time: " + sTime.ToString () + " ms";
	}

	public void mulballs()
		{ 
				if (mballs == 0) {
						mballs = 1;
				} 
				else {
						mballs = 0;
				}
		}
	
	public void pauseGame()
	{
				if (Time.timeScale == 1.0f) {
						Time.timeScale = 0.0f;
				} 
				else {
						Time.timeScale = 1.0f;
				}
	}

	IEnumerator wait() //This is code routine for wait
	{
				yield return new WaitForSeconds (10);
				SceneManager.LoadScene (0);
	}
	
	public void RestartNow()
	{
				SceneManager.LoadScene (0);
	} 
	
	void SetScoreText()
	{
				scoreCount.text = "Score: " + score.ToString ();
				if (score == 2000)
				{
						winText.text = "YOU WIN!";
						gameState = PinballGameState.won;
						StartCoroutine ("wait");

				}

				if (gameState == PinballGameState.lost)
				{
						winText.text = "YOU LOSE!";
						StartCoroutine ("wait");

				}
	}

    public void WonGame()
    {
        Time.timeScale = 0.0f; //Pause game
        gameState = PinballGameState.won;
    }

    public void LostBall()
    {
        int ballsLeft = GameObject.FindGameObjectsWithTag("Player").Length;
        if(ballsLeft<=1)
        {
            //Was the last ball..
            //SetGameOver();
			gameState = PinballGameState.lost;
        }
    }
	/*
    public void SetGameOver()
    {
        //Time.timeScale = 0.0f; //Pause game
        gameState = PinballGameState.lost;
    } */
}
