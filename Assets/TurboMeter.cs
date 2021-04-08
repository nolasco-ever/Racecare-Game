using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboMeter : MonoBehaviour
{
	public Image turbo;
	public static float maxTurbo = 100f;
	public static float currentTurbo;
	public float useLimit;
	public static bool beingUsed;

	public GameObject turboFire;

    // Start is called before the first frame update
    void Start()
    {
        currentTurbo = 0f;
        turboFire.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	turbo.fillAmount = currentTurbo/maxTurbo;

    	if(currentTurbo == 0){
    		useLimit = 50f;
    	}

    	if(currentTurbo < 100 && beingUsed == false){
    		currentTurbo += 0.15f;
    	}
    	else if(currentTurbo >= 100){
    		currentTurbo+=0;
    		currentTurbo = 100;
    	}

    	if(currentTurbo >= useLimit && Input.GetKey(KeyCode.Space)){
    		currentTurbo-=0.5f;
    		beingUsed = true;
    		useLimit = currentTurbo;
    		turboFire.SetActive(true);

    		if(currentTurbo < 0){
    			currentTurbo = 0;
    		}
    		
    	}
    	else{
    		beingUsed = false;
    		turboFire.SetActive(false);
    	}
    }
}
