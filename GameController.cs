using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public int startWait;
	public int waveWait;
	public GUIText ScoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public int Score;

	private bool restart;
	private bool gameOver;

	void Start(){
		restart = false;
		gameOver = false;
		restartText.text  = "";
		gameOverText.text  = "";
		Score = 0;
		updateScore ();
		StartCoroutine (spawnWaves ());
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode .R )){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
	IEnumerator spawnWaves(){
		while (true) {
			yield return new WaitForSeconds (startWait);
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random .Range (0,hazards .Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text  = "Para reiniciar presiona 'R'";
				restart = true;
				break;
			}
		}
	}

	public void AddScoreValue(int newScoreValue){
		Score += newScoreValue ;
		updateScore(); 
	}

	void updateScore(){
		ScoreText.text = "Puntuacion: " + Score;
	}

	public void GameOver(){
		gameOverText.text  = "Game Over - Programado por Gandhy";
		gameOver = true;
	}
}
