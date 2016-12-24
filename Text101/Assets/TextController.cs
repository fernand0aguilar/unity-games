using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	
	public Text myText;
	public enum Status {locked_cell, bed, b_sleep, b_sleep_1, window, mirror, library, l_book, l_key, l_help_guard, freedom};
	
	public Status currentStatus;
	public bool key_on_book = false;
	
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
			case Status.b_sleep_1:
				state_bed_sleep_1_action();
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
			case Status.l_help_guard:
				state_help_guard_action();
				break;
			case Status.freedom:
				state_freedom();
				break;
		}
	}
	
	void state_cell(){
		currentStatus = Status.locked_cell;			  
		
		myText.text = "You are locked in your cell. Reading and thinking about freedom are the only thing that keeps you alive.\n" +
					  "After a couple of years, the guards actually respect you.\n\n" +
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
		myText.text = "Your sheets are disgusting. \nHow can a human beeing sleep in this!?\n" +
					  "You feel tired. And decide to lay down.\nEven if the sheets are dirtier than the deans moral.\n\n" +
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
			currentStatus = Status.b_sleep_1;
		}
		else if(Input.GetKeyDown(KeyCode.U)){
			currentStatus = Status.b_sleep_1;
		}
	}
	void state_bed_sleep_1_action(){
		myText.text = "You close your eyes again for two more hours.\n Your body can't stand one more minute on this bed." +
			"You get up.\n\n Press 'U' to continue";
		
		if(Input.GetKeyDown(KeyCode.U)){
			currentStatus = Status.locked_cell;
		}
	}
	
	void state_mirror_action(){
		myText.text = "You look at yourself trough the mirror.\n\nThe beard is longer than you have ever kept it.\n" +
					  "Like a lumberjack beard, the style is definitely remarkable.\n\n" +
					  "Press 'ENTER' to return roaming in your cell";
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.locked_cell;						  	
	}
	
	void state_window_action(){
		myText.text = "You look trough the windown holding the bars with your hands.\n\n" +
				"The view is ugly.\n There is nothing but guards, iron and concrete.\n" +
				"\nYou miss the nature!" +
				"\n\nPress ENTER to continue";
		
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.locked_cell;	
	}
	void state_library_action(){
		if (key_on_book == false){
			myText.text = "After reading 'Thus spoke Zarastrusta', the unique book as it is, you request another great book.\n\n" +
						  "Since Bruce, the guard, is a ambicious reader, just like you,\n he decides to take you to the library, in order to find a new book to read.\n" +
						  "It is against the rules. But you are the most calm inmate on there, and the prison also has many other guards. It is impossible to break trough." +
						  "\n\nPress ENTER to continue";
			if(Input.GetKeyDown(KeyCode.Return))
				currentStatus = Status.l_book;
		}
		else if (key_on_book == true){
			myText.text = "FREEDOM\n\n PRESS ENTER TO CONTINUE";
			if(Input.GetKeyDown(KeyCode.Return))
				currentStatus = Status.freedom;
				
			//TODO --> INVENT WAY TO GET BOOK 
			//			 			AND THEN CONTINUE STORY LINE
		}
	}
	
	void state_book_action(){
		myText.text = "You two get at the library and are talking about books and authors.\nIn a moment of pure 'what the fuck'," +
			"Bruce fall on the ground. Completly blacked out. You think what the hell just happened, but then think also on the opportunities.\n" +
			"Since he just felt down blacked out, you have a few moments alone with his body, and with his tools... It is time to act and be free.\n" +
			"\nBut you are smart and plans the future.\n The keys are on his pocket.\n\n" +
			"Press 'G' to call for help. 'K' to Pick up the set of keys";
		
		if(Input.GetKeyDown(KeyCode.G))
			currentStatus = Status.l_help_guard;
		else if(Input.GetKeyDown(KeyCode.K))
			currentStatus = Status.l_key;
	}
	
	void state_key_action(){
		key_on_book = true;
		
		myText.text = "In a moment of pure higher concsiousness, you pick only your cell number key out of the set of keys in his pocket.\n" +
			"Hiding it on the book called 'Mathematics for experts', using his knife to crave a hole, inserting in it.\n"+
			"You put the book on the shelf, and call for help" +
			"Press 'ENTER' to continue";
		
		if(Input.GetKeyDown(KeyCode.Return)){
			currentStatus = Status.l_help_guard;
		}	
	}
	
	void state_help_guard_action(){
		if (key_on_book == true){
			myText.text = "You have helped the guard. Calling other guards and explaning the situation."+
				"By some sort of miracle, he is okay and did not noticed the key missing.\n" +
				"You now have the oportunity to escape. Just need to get the book wich the key is inside.\n" +
				"Press ENTER to return to your cell and think about getting the book"; 
		}
		
		else{
			myText.text = "You've helped the guard.\n\n After much explanations, the routine go back as usual.\n\nYou FAILED to escape the prison by making good moral choices!!"+
				"\n\n Press ENTER to return to your cell and try it again.";
		}
		
		if(Input.GetKeyDown(KeyCode.Return)){
			currentStatus = Status.locked_cell;
		}
	}
	
	void state_freedom(){
		myText.text = "YOu use the key and find freedom congrats";
	}
	
}
