using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	
	public Text myText;
	public enum Status {locked_cell, bed, b_sleep, window, mirror, library, l_guard, l_book, l_key, freedom};
	
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
			case Status.library():
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
	
	void state_window_action(){
		myText.text = "You look trough the windown. Holding the bars with your hands.\n" +
					"The view is ugly. There is nothing but guards, iron and concrete.\n" +
					"\nYou miss the nature!" +
					"\n\nPress ENTER to continue";
		
		if(Input.GetKeyDown(KeyCode.Return))
			currentStatus = Status.locked_cell;	
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
			myText.text = "You close your eyes again for two more hours. Your body can't stand one more minute on this bed.
						  "You get up\n\n Press 'U' to continue;
		}
		else if(Input.GetKeyDown(KeyCode.U)){
			currentStatus = Status.locked_cell;
		}
	}
	void state_break_ground(){
		myText.text = "Bruce: - It seems like this gnash is hollow. Maybe whe could break it to check on it" + 
				"Can you pass me something to smash it?" +
				"\n\nPress 'B' to pick a metal bar from crashed bed";
		if(Input.GetKeyDown(KeyCode.B)){
			currentStatus = Status.ground_1;
		}
	}
	void state_open_tunnel(){
		myText.text = "After opening the groud. Bruce finds a kind of tunnel.\n" + 
				"It must have been digged before by someone trying to escape! Those lazy pigs only have only tap the top of it" +
				"I'm going in! \nLets find out where it leads\n\n Press E to enter in the tunnel.";
		if(Input.GetKeyDown(KeyCode.E)){		
			currentStatus = Status.tunnel;
		}
	}
	void state_scaping_tunnel(){
		myText.text = "You are in the tunnel.\n Following Bruce in this stinky and dark path.\n\n\n"+
			"Press enter to continue";
		if(Input.GetKeyDown(KeyCode.Return)){		
			currentStatus = Status.freedom;
		}
	}
	
	void state_freedom(){
		myText.text = "After two hours of dragging yourselves trough the hole. He finally yeals:\n\n" +
			"Bruce: - I'm seeing a FUCKING LIGHT HAHAHAHA\n\n"+
				"And then, suddently, the tunnel ends. And you find freedom in the forest.\n\n\n" +
				"Bruce: - Thats it my friend. We are free!! Let's run to scape.";
	}
	void state_check_lock(){
		myText.text = "This lock seems so difficult to open. Bruce has already" +
					"Tried to hijack it. With no Success. \n\n You try it yourself." +
					"You check inside the hole. There is some rust in it.\n\n" +
					"You force it to open!\n Nothing happens." +
					"\n\nPress ENTER to continue";
		state_cell();
	}
	
}
