using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanister : MonoBehaviour
{
    public SpriteRenderer canister;

    void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "player"){
    		Debug.Log("Gas Trigger Enter");
    		canister.enabled = false;
    		GasMeter.currentGas += 10;
	
    		if (GasMeter.currentGas > 100){
    			GasMeter.currentGas = 100;
    		}
    	}
    }
}
