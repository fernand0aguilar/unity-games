using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	
	public Text myText;
	public enum Status {locked_cell, bed, b_sleep, window, mirror, library, l_guard, l_book, l_key, l_help_guard, freedom};
	
	public Status currentStatus;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentStatus){
			case Status.locked_cell:
				state_cell();
				break;
			case Status.bed:
				state_bed_action();
				break;
			case Status.b_sleep:
				state_bed_sleep_action();
				break;
			case Status.window:
				state_window_action();
				break;
			case Status.mirror:
				state_mirror_action();
				break;
			case Status.library:
				state_library_action();
				break;
			case Status.l_book:
				state_book_action();
				break;
			case Status.l_key:
				state_key_action();
				break;
			case Status.l_guard:
				state_guard_action();
				break;
		}
	}
	
	void state_cell(){
		currentStatus = Status.locked_cell;			  
		
		myText.text = "You are locked in your cell. Reading and thinking about freedom are the only thing that keeps you alive.\n" +
					  "After a couple of years, you and the guards have quite a good relashionship.\n" +
					  "Press 'B' to lay in bed.\n" +
					  "'W' to look trough the window.\n" + 
					  "'M' to look at the mirror.\n" +
					  "'L' request a new book from library.\n";
					  
		if(Input.GetKeyDown(KeyCode.B))
			currentStatus = Status.bed;
		else if(Input.GetKeyDown(KeyCode.W))
			currentStatus = Status.window;
		else if(Input.GetKeyDown(KeyCode.M))
			currentStatus = Status.mirror;
		else if(Input.GetKeyDown(KeyCode.L))
			currentStatus = Status.library;
	}
	
	void state_bed_action(){
		myText.text = "Your sheets are disgusting. How can a human beeing sleep in this?\n" +
					  "You feel tired. And decide to lay even if the sheets are dirtier than the deans moral.\n\n" +
					  "Press 'S' to sleep. 'U' to get up again.";
			
		if(Input.GetKeyDown(KeyCode.S)) 
			currentStatus = Status.b_sleep;
		else if(Input.GetKeyDown(KeyCode.U))
			currentStatus = Status.locked_cell;
	}
	
	void state_bed_sleep_action(){
		myText.text = "You are feeling like there is nothing better to do with your time." +
					  "Taking a nap is the best option that you have. Even in these sheets. \nSleeping is sleeping." +
					  "\n\n...6 hours later...\nYou wake up feeling alive.\n Press 'M' to sleep more. 'U' to get up";
		if(Input.GetKeyDown(KeyCode.M)){ 
			myText.text = "You close your eyes again for two more hours.\n Your body can't stand one more minute on this bed." +
						  "You get up.\n\n Press 'U' to continue";
		}
		else if(Input.GetKeyDown(KeyCode.U)){
			currentStatus = Status.locked_cell;
		}
	}
	
	void state_mirror_action(){
		myText.text = "You look at yourself at the mirror. The beard is longer than you have ever kept it.\n" +
					  "Like a lumberjack beard, the slyte is definitly remarkable." +
					  "Press 'ENTER' to return roaming in your cell";
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.locked_cell;						  	
	}
	
	void state_window_action(){
		myText.text = "You look trough the windown. Holding the bars with your hands.\n" +
			"The view is ugly. There is nothing but guards, iron and concrete.\n" +
				"\nYou miss the nature!" +
				"\n\nPress ENTER to continue";
		
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.locked_cell;	
	}
	void state_library_action(){
		myText.text = "After reading 'Thus spoke Zarastrusta', the unique book, you are on the hunt for another great book as it.\n" +
					  "Since Bruce, the guard, is a ambicious reader, just like you, he decides to take you to the library, in order to find a new book to read" +
					  "It is against the rules. But you are the most calm inmate on there, and the prison also has many other guards. It is impossible to break trough." +
					  "\n\nPress ENTER to continue";
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.l_book;
	}
	void state_library_action(){
		myText.text = "TODO";
		
		if(Input.GetKeyDown(KeyCode.G))
			currentStatus = Status.l_help_guard;
		else if(Input.GetKeyDown(KeyCode.K))
			currentStatus = Status.l_key;
	}
	
	//TODO Finish library actions, library keys, library help guard, and hide key on book;
	
	void state_freedom(){
		myText.text = "";
	}
	
}
