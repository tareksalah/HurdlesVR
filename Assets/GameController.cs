using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public TextMesh infoText;
	public Player player;
	public float gameTimer = 0f;


	private float restartTimer = 5f;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (player.reachedFinishLine == false) {
			gameTimer += Time.deltaTime;
			infoText.text = "Avoid the Obstacles\n Press the space button to jump!\n Time:" + Mathf.Floor (gameTimer);
		} else {
			infoText.text = "You Won!\n Your Time was:" + Mathf.Floor (gameTimer);

			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}

		
	}
}
