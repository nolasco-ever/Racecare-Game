using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class NPCVehicles : MonoBehaviour
{	[SerializeField]
	public Transform[] waypoints;	//array to hold all the waypoints in the sprite's path

	[SerializeField]
	public float moveSpeed = 2.0f;

	public int wayPointIndex = 0;

	private Scene scene;

	public Animator npc;
	public GameObject thisNPC;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[wayPointIndex].transform.position;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(scene.name == "Stage 1"){
            if (transform.name == "npc9" || transform.name == "npc10"){
                if(CrosswalkTrigger.s1activate == true){
                    moveSpeed = 15.0f;
                }
                else{
                    moveSpeed = 0.0f;
                }
            }
        }
        else if(scene.name == "Stage 2"){
        	if (transform.name == "npcCross1"){
        		if(CrosswalkTrigger.s2activate1 == true){
        			moveSpeed = 10.0f;
        		}
        		else{
        			moveSpeed = 0.0f;
        		}
        	}
            else if(transform.name == "npcCross2"){
                if(CrosswalkTrigger.s2activate2 == true){
                    moveSpeed = 7.5f;
                }
                else{
                    moveSpeed = 0.0f;
                }
            }
        }

        if(transform.name == "npc2"){

        	switch(wayPointIndex){
        		case 2:
        			npc.SetBool("turnRight", true);
        			npc.SetBool("turnLeft", false);
        			break;
        		case 8:
        			npc.SetBool("turnRight", false);
        			npc.SetBool("turnLeft", true);
        			break;
        		case 11:
        			npc.SetBool("turnRight", true);
        			npc.SetBool("turnLeft", false);
        			break;
        		case 34:
        			npc.SetBool("turnRight", false);
        			npc.SetBool("turnLeft", true);
        			break;
        		case 37:
        			npc.SetBool("turnRight", true);
        			npc.SetBool("turnLeft", false);
        			break;
        		default:
        			npc.SetBool("turnRight", false);
        			npc.SetBool("turnLeft", false);
        			break;
        	}
        }
        else if(transform.name == "npc3"){
        	switch(wayPointIndex){
        		case 25:
        			npc.SetBool("turnCrosswalkOne", true);
        			npc.SetBool("turnCrosswalkTwo", false);
        			npc.SetBool("turnLeft", false);
        			npc.SetBool("turnRight", false);
        			break;
        		case 32:
        			npc.SetBool("turnCrosswalkOne", false);
        			npc.SetBool("turnCrosswalkTwo", false);
        			npc.SetBool("turnLeft", true);
        			npc.SetBool("turnRight", false);
        			break;
        		case 38:
        			npc.SetBool("turnCrosswalkOne", false);
        			npc.SetBool("turnCrosswalkTwo", false);
        			npc.SetBool("turnLeft", false);
        			npc.SetBool("turnRight", true);
        			break;
        		case 50:
        			npc.SetBool("turnCrosswalkOne", false);
        			npc.SetBool("turnCrosswalkTwo", false);
        			npc.SetBool("turnLeft", true);
        			npc.SetBool("turnRight", false);
        			break;
        		case 52:
        			npc.SetBool("turnCrosswalkOne", false);
        			npc.SetBool("turnCrosswalkTwo", true);
        			npc.SetBool("turnLeft", false);
        			npc.SetBool("turnRight", false);
        			break;
        		default:
                    npc.SetBool("turnCrosswalkOne", false);
                    npc.SetBool("turnCrosswalkTwo", false);
                    npc.SetBool("turnLeft", false);
                    npc.SetBool("turnRight", false);
        			break;
        	}
        }
        else if(transform.name == "npc4"){
            switch(wayPointIndex){
                case 26:
                    npc.SetBool("turn1", true);
                    npc.SetBool("turn2", false);
                    npc.SetBool("turn3", false);
                    npc.SetBool("turn4", false);
                    break;
                case 27:
                    npc.SetBool("turn1", false);
                    npc.SetBool("turn2", true);
                    npc.SetBool("turn3", false);
                    npc.SetBool("turn4", false);
                    break;
                case 50:
                    npc.SetBool("turn1", false);
                    npc.SetBool("turn2", false);
                    npc.SetBool("turn3", true);
                    npc.SetBool("turn4", false);
                    break;
                case 71:
                    npc.SetBool("turn1", false);
                    npc.SetBool("turn2", false);
                    npc.SetBool("turn3", false);
                    npc.SetBool("turn4", true);
                    break;
                default:
                    npc.SetBool("turn1", false);
                    npc.SetBool("turn2", false);
                    npc.SetBool("turn3", false);
                    npc.SetBool("turn4", false);
                    break;
            }
        }
        else if(transform.name == "npc5"){
            switch(wayPointIndex){
                case 37:
                    npc.SetBool("turn1", true);
                    npc.SetBool("idle", false);
                    npc.SetBool("park", false);
                    break;
                case 42:
                    npc.SetBool("turn1", false);
                    npc.SetBool("idle", true);
                    npc.SetBool("park", false);
                    break;
                case 58:
                    npc.SetBool("turn1", false);
                    npc.SetBool("idle", false);
                    npc.SetBool("park", true);
                    break;
            }
        }
    }

    public void Move(){
    	if(wayPointIndex <= waypoints.Length - 1){
    		transform.position = Vector3.MoveTowards(transform.position, waypoints[wayPointIndex].transform.position, moveSpeed * Time.deltaTime);

    		if(transform.position == waypoints[wayPointIndex].transform.position){
    			wayPointIndex+=1;
    		}
    	}
    }
}
