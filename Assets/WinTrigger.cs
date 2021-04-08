using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public Animator winnerPanel;
	public Animator stageComplete;
	public Animator choiceBoard;

	public Canvas winnerScreen;

	void Start(){
		winnerScreen.enabled = false;
	}

   void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "player"){
    		Debug.Log("winner");
    		FollowPlayer.following = false;
    		GasMeter.burnAmount = 0.0f;
    		raceCarMovement.move = 0.5f;
    		GasMeter.won = true;

    		winnerScreen.enabled = true;
    		winnerPanel.SetBool("intro", true);
    		stageComplete.SetBool("intro", true);
    		choiceBoard.SetBool("intro", true);
    	}

    }
}
