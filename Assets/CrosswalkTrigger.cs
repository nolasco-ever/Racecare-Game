using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrosswalkTrigger : MonoBehaviour
{
	public static bool s1activate;
    public static bool s2activate1;
    public static bool s2activate2;

    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        s1activate = false;
        s2activate1 = false;
        s2activate2 = false;
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "player"){
            if(scene.name == "Stage 1"){
                s1activate = true;
            }
            else if(scene.name == "Stage 2"){
            	if(gameObject.name == "CrosswalkTrigger1"){
    				s2activate1 = true;
    			}
    			else if(gameObject.name == "CrosswalkTrigger2"){
    				s2activate2 = true;
    			}
            }
    	}

    }
}
