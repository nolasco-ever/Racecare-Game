using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMeter : MonoBehaviour
{
	public Image gas;
	public static float maxGas = 100f;
	public static float currentGas;
	public static float burnAmount;
	public static bool won;

    // Start is called before the first frame update
    void Start()
    {
        currentGas = 50f;
        burnAmount = 0.025f;
        won = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	if(won == false){
    		gas.fillAmount = currentGas/maxGas;
       		currentGas -= burnAmount;

       		if (currentGas < 0){
       			currentGas = 0;
       			Debug.Log("no more gas");
       		}
       		else if (currentGas > 100){
       			currentGas = 100;
       		}
    	}
    }
}
