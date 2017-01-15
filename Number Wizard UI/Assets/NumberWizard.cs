using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	
	public Text numberText;
	public int maxGuessesAllowed = 0;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame(){
		max = 1000;
		min = 1;
		guess = Random.Range(min, max+1);
		
		numberText.text = guess.ToString();
	}
		
	public void higherGuess(){
		min = guess;
		NextGuess();	
	}
	
	public void lowerGuess(){
		max = guess;
		NextGuess();
	}
		
	void NextGuess(){
		guess = (max + min) / 2;
		
		maxGuessesAllowed++;
		if(maxGuessesAllowed >= 10){
			Application.LoadLevel("Lose");
		}
		
		numberText.text = guess.ToString();
	}
	
}
