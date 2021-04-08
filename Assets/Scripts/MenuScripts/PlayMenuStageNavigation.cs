using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenuStageNavigation : MonoBehaviour
{
	public int totalStages;
	public int clicks = 0;
	public int activeStage;
	public Button next;
	public Button previous;
	public Animator backButton;
	public Animator forwardButton;
    // Start is called before the first frame update
    void Start()
    {
    	totalStages = gameObject.transform.childCount;
    	Debug.Log(totalStages);

    	for(int i = 1; i < totalStages; i++){
    		gameObject.transform.GetChild(i).gameObject.SetActive(false);
    	}

    	activeStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextButtonPointerEnter(){
    	forwardButton.SetBool("hover", true);
    }

    public void nextButtonPointerExit(){
    	forwardButton.SetBool("hover", false);
    }

    public void previousButtonPointerEnter(){
    	backButton.SetBool("hover", true);
    }

    public void previousButtonPointerExit(){
    	backButton.SetBool("hover", false);
    }

    public void nextButton(){
    	clicks++;

    	forwardButton.SetBool("clicked", true);

    	if (clicks > (totalStages-1)){
    		clicks = totalStages-1;
    	}

    	for(int i = 0; i < totalStages; i++){
    		if(i == clicks){
    			gameObject.transform.GetChild(i).gameObject.SetActive(true);
    		}
    		else{
    			gameObject.transform.GetChild(i).gameObject.SetActive(false);
    		}
    	}

    	forwardButton.SetBool("clicked", false);	
    }

    public void previousButton(){
    	clicks--;

    	backButton.SetBool("clicked", true);

    	if (clicks < 0){
    		clicks = 0;
    	}

    	for(int i = 0; i < totalStages; i++){
    		if(i ==clicks){
    			gameObject.transform.GetChild(i).gameObject.SetActive(true);
    		}
    		else{
    			gameObject.transform.GetChild(i).gameObject.SetActive(false);
    		}
    	}

    	backButton.SetBool("clicked", false);
    }

    public void GoToLevel(){
    	string thisStage = gameObject.transform.GetChild(clicks).name;
    	SceneManager.LoadScene(thisStage);
    }

    public void BackToMenu(){
    	SceneManager.LoadScene("MainMenu");
    }
}
