using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	#region definitions 
	public Text myText;
	
	public enum Status {
		locked_cell, window, mirror,
		bed, b_sleep, b_sleep_1, 
		library, l_book, l_key, l_help_guard,
		favor_0, f_john, f_taylor, f_bruce,
		bruce_1, taylor_1, get_book, escape, freedom
	};
	
	public Status currentStatus;
	
	public bool key_on_book = false;
	#endregion
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentStatus){
			case Status.locked_cell:
				cell();
				break;
			case Status.bed:
				bed_action();
				break;
			case Status.b_sleep:
				bed_sleep_action();
				break;
			case Status.b_sleep_1:
				bed_sleep_1_action();
				break;
			case Status.window:
				window_action();
				break;
			case Status.mirror:
				mirror_action();
				break;
			case Status.library:
				library_action();
				break;
			case Status.l_book:
				book_action();
				break;
			case Status.l_key:
				key_action();
				break;
			case Status.l_help_guard:
				help_guard_action();
				break;
			case Status.favor_0:
				ask_favor_0();
				break;
			case Status.f_john:
				ask_john();
				break;
			case Status.f_taylor:
				ask_taylor();
				break;
			case Status.f_bruce:
				ask_bruce();
				break;
			case Status.bruce_1:
				bruce_help();
				break;
			case Status.taylor_1:
				taylor_chantage();
				break;
			case Status.get_book:
				get_book();
				break;
			case Status.escape:
				escape();
				break;
			case Status.freedom:
				freedom();
				break;
		}
	}
	
	#region first layer handler methods
	void cell(){
		currentStatus = Status.locked_cell;			  
		
		myText.text = "You are locked in your cell.\n\n Reading and thinking about freedom are the only thing that keeps you alive.\n" +
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
	
	void bed_action(){
		myText.text = "Your sheets are disgusting.\nHow can a human beeing sleep in this!?\n\n" +
					  "You feel tired. And decide to lay down.\nEven if the sheets are dirtier than the deans moral.\n\n" +
					  "Press 'S' to sleep. 'U' to get up again.";
			
		if(Input.GetKeyDown(KeyCode.S)) 
			currentStatus = Status.b_sleep;
		else if(Input.GetKeyDown(KeyCode.U))
			currentStatus = Status.locked_cell;
	}
	
	void bed_sleep_action(){
		myText.text = "You are feeling like there is nothing better to do with your time.\n\n" +
					  "Taking a nap is the best option that you have.\n Even in these sheets. Sleeping is sleeping." +
					  "\n\n...6 hours later...\nYou wake up feeling alive.\n\n Press 'M' to sleep more. 'U' to get up";
					  
		if(Input.GetKeyDown(KeyCode.M)){ 
			currentStatus = Status.b_sleep_1;
		}
		else if(Input.GetKeyDown(KeyCode.U)){
			currentStatus = Status.b_sleep_1;
		}
	}
	
	void bed_sleep_1_action(){
		myText.text = 	"You close your eyes again for two more hours.\n\n Your body can't stand one more minute on this bed." +
						"\n\nYou get up.\n\n Press 'U' to continue";
		
		if(Input.GetKeyDown(KeyCode.U)){
			currentStatus = Status.locked_cell;
		}
	}
	
	void mirror_action(){
		myText.text = "You look at yourself trough the mirror.\n\nThe beard is longer than you have ever kept it.\n" +
					  "Like a lumberjack beard, the style is definitely remarkable.\n\n" +
					  "Press 'ENTER' to return roaming in your cell";
					  
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.locked_cell;						  	
	}
	
	void window_action(){
		myText.text = 	"You look trough the windown holding the bars with your hands.\n\n" +
						"The view is ugly.\n There is nothing but guards, iron and concrete.\n" +
						"\nYou miss the nature!" +
						"\n\nPress ENTER to continue";
		
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.locked_cell;	
	}
	
	void library_action(){
		if (key_on_book == false){
		
			myText.text = "After reading 'Thus spoke Zarastrusta', the unique book as it is, you request another great book.\n\n" +
						  "Since Bruce, the guard, is a ambicious reader, just like you,\n he decides to take you to the library, in order to find a new book to read.\n" +
						  "It is against the rules. But you are the most calm inmate on there, and the prison also has many other guards. It is impossible to break trough." +
						  "\n\nPress ENTER to continue";
						  
			if(Input.GetKeyDown(KeyCode.Return))
				currentStatus = Status.l_book;
		}
		
		else if (key_on_book == true){
		
			currentStatus = Status.favor_0;
		}
	}
	
	void book_action(){
		myText.text = 	"You two get at the library and are talking about books and authors.\nIn a moment of pure 'what the fuck'," +
						"Bruce fall on the ground. Completly blacked out. You think what the hell just happened, but then think also on the opportunities.\n" +
						"Since he just felt down blacked out, you have a few moments alone with his body, and with his tools... It is time to act and be free.\n" +
						"\nBut you are smart and plans the future.\n The keys are on his pocket.\n\n" +
						"Press 'G' to call for help. 'K' to Pick up the set of keys";
		
		if(Input.GetKeyDown(KeyCode.G))
			currentStatus = Status.l_help_guard;
		
		else if(Input.GetKeyDown(KeyCode.K))
			currentStatus = Status.l_key;
	}
	
	void key_action(){
		key_on_book = true;
		
		myText.text = 	"You pick only your cell number key out of the set of keys in his pocket.\n" +
						"Hiding it on the book called 'Mathematics for experts', using his knife to crave a hole, inserting in it.\n\n"+
						"You put the book on the shelf, and call for help.\n\n" +
						"Press 'ENTER' to continue";
		
		if(Input.GetKeyDown(KeyCode.Return)) 		{ currentStatus = Status.l_help_guard; }
	}
	
	void help_guard_action(){
		if (key_on_book == true){
			myText.text = 	" You help the guard by massaging him. His heart is back on beating.\n\n" +
							"By some sort of miracle, he is okay and did not noticed the key missing.\n\n" +
							"You now have the oportunity to escape. Just need to get the book wich the key is inside.\n\n" +
							"Press ENTER to return to your cell and think about getting the book"; 
		}
		
		else {
			myText.text = 	"You've helped the guard.\n\n After much explanations, the routine go back as usual.\n\n"+
							"You FAILED to escape the prison by making good moral choices!!"+
							"\n\n Press ENTER to return to your cell and try it again.";
		}
		
		if(Input.GetKeyDown(KeyCode.Return))		{ currentStatus = Status.locked_cell; }
	}
	#endregion
	#region second layer state methods
	void ask_favor_0(){
		myText.text = 	"You need someone to get the book and can be trusty.\n\nWho would you ask for a favor?\n\n"+
						"John - Your closest allied\nTaylor - The book guy.\n\n" +
						"Press 'J' to ask John\nPress 'T' to ask Taylor";
		
		if(Input.GetKeyDown(KeyCode.J))				{ currentStatus = Status.f_john; }
		
		else if(Input.GetKeyDown(KeyCode.T))		{ currentStatus = Status.f_taylor; }
	}
	
	void ask_john(){
		myText.text = 	"John is an allied. He is your closest one.\n\nYou explain the whole history to him, " +
						"asking for help to get the book.\n\nIn the next month his jailtime ends.\n\n"+
						"After much dialog. He decides that won't help.\n" +
						"You are disapointed. But forget him.\n\n" +
						"Press 'F' to ask for another person";
						
		if(Input.GetKeyDown(KeyCode.F)){
			currentStatus = Status.favor_0;
		}
	}
	
	void ask_taylor(){
		myText.text = "TODO";
	}
	
	void ask_bruce(){
	
	}
	void bruce_help(){
	
	}
	void taylor_chantage(){
	
	}
	void get_book(){
	
	}
	void escape(){
	
	}
	
	void freedom(){
		myText.text = "YOu use the key and find freedom congrats";
	}
}
