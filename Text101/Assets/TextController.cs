using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	
	public Text myText;
	public enum Status {cell_0, bed, b_lay, b_sleep, window, mirror, library, l_guard, l_book, l_key, freedom};
	
	public Status currentStatus;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentStatus){
			case Status.cell_0:
				state_cell();
				break;
			case Status.window:
				state_window_action();
				break;
			case Status.bed:
				state_bed_action();
				break;
			case Status.mirror():
				state_mirror_action();
				break;
			case Status.library();
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
		currentStatus = Status.cell_0;			  
		
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
	
	void state_talk_bruce(){
		myText.text = "You two are not the best friends.\n But the partnership is unavoidable.\n\n" + 
				  	  "You ask about some book recomendations.\n"+
					  "Bruce recommends his favorite, 'Thus Spoke Zarasthustra'.\n" +
					  "You thank him and return to your confort." +
		   		  	  "\n\nPress ENTER to continue";
		state_cell();
	}
	
	void state_look_window(){
		myText.text = "You look trough the windown. Holding the bars with your hands.\n" +
					"The view is ugly. There is nothing but guards, iron and concrete.\n" +
					"\nYou miss the nature!" +
					"\n\nPress ENTER to continue";
		state_cell();
	}
	
	void state_lay_on_bed(){
		myText.text = "Your sheets are disgusting. How can a human beeing sleep in this?\n" +
					  "You feel tired. And decide to lay on the upper bed." +
					  "\n\nThe structure of the bed start to ramble.\nIt seems like it is going to fall." +
				 	  "\n\nPress ENTER to continue";
			
		if(Input.GetKeyDown(KeyCode.Return)) 
			currentStatus = Status.fall_bed;
	}
	
	void state_fall_bed(){		
		myText.text = "You climbed on it. With much noise beeing made by the bed structure." +
					"\n\nThe whole thing is falling apart!\n The bed breakes. You and hit the head on the ground\n" +
					"The world turns black. You passed out.\n" +
					"\n\nPress ENTER to continue";
		if(Input.GetKeyDown(KeyCode.Return))	
			currentStatus = Status.unconcious;
		
	}
	
	void state_unconcious(){
		myText.text = "Bruce: - You have quite a hard head. It even gnashed the ground!!!\n" +
				"You: - What? It cant be possible. I feel fine. Hope that it is all good with my head.\n" +
				"\nBruce: - Let's check on this ground. Can you help me?\n\n\n" +
				"Press 'Y' to help Bruce. 'ENTER' to rest";
		if(Input.GetKeyDown(KeyCode.Y)){
			currentStatus = Status.ground_0;
		}
		else if(Input.GetKeyDown(KeyCode.Return)){
			currentStatus = Status.cell_0;
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
