using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoltTrigger : MonoBehaviour
{
    //Set the variables that we will be using to display the number of
    //bolts collected on the screen
	public SpriteRenderer nut;
	public static float count = 0;
	public TMP_Text nutAmountText;
    public TMP_Text nutWinnerScreen;
    
    public void Update(){
    	nutAmountText.text = count.ToString();
        nutWinnerScreen.text = count.ToString();
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "player"){
    		count++;
    		nut.enabled = false;
    	}

    }
}
