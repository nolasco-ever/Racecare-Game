using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class raceCarMovement : MonoBehaviour
{
	private Scene scene;

	public Rigidbody2D playerCar;
	public static float move = 0.125f;
    public float cameraOffset = 2.95f;
    public bool isLeft, isRight;
    public Vector3 push;
    private bool crashed;
    public Canvas loserScreen;
    public float lane;

    public GameObject turboBoost;

    public Animator frontWheelAnimations;
    public Animator bodyAnimations;
    public Animator fullCarAnimations;
    public Animator loserPanel;
    public Animator youLost;
    public Animator choiceBoard;
    public Animator turbo;
    // Start is called before the first frame update
    void Start()
    {
    	scene = SceneManager.GetActiveScene();
        playerCar = this.GetComponent<Rigidbody2D>();
        isRight = true;
        isLeft = false;
        move = 0.125f;

        loserScreen.enabled = false;

        lane = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GasMeter.won == false){
            if(TurboMeter.beingUsed == true){
                if(move < 0.25f){
                    move += 0.005f;
                    GasMeter.burnAmount = 0.05f;
                    FollowPlayer.zOffset -= 1.0f;
                }
            }
            else{
                if(move > 0.125f){
                    move-=0.005f;
                    FollowPlayer.zOffset += 1.0f;
                }
                GasMeter.burnAmount = 0.025f;
            }
        }

        if(GasMeter.currentGas == 0 || crashed == true){
            loserScreen.enabled = true;
            BoltTrigger.count = 0;

            move -= 0.001f;
            if(move <= 0){
                move = 0;

                loserPanel.SetBool("intro", true);
                youLost.SetBool("intro", true);
                choiceBoard.SetBool("intro", true);
                Time.timeScale = 1.0f;
            }

            push = new Vector3(0,move,0);
            transform.position += push;
            frontWheelAnimations.SetBool("isDriving", false);
            bodyAnimations.SetBool("isDriving", false);
            frontWheelAnimations.SetBool("crashed", true);
            bodyAnimations.SetBool("crashed", true);
            fullCarAnimations.SetInteger("lane", 0);

        }
        else{
            push = new Vector3(0,move,0);
            transform.position += push;
            frontWheelAnimations.SetBool("isDriving", true);
            bodyAnimations.SetBool("isDriving", true);

            if(scene.name == "Stage 1"){
            	if (Input.GetKey(KeyCode.LeftArrow) && isRight == true){

            	    frontWheelAnimations.SetBool("leftTurn", true);
            	    frontWheelAnimations.SetBool("rightTurn", false);
            	    fullCarAnimations.SetBool("leftTurn", true);
            	    fullCarAnimations.SetBool("rightTurn", false);
    	
            	    frontWheelAnimations.SetBool("isDriving", true);
            	    bodyAnimations.SetBool("isDriving", true);
	
            	    turbo.SetBool("turnLeft", true);
            	    turbo.SetBool("turnRight", false);
    	
            	    isRight = false;
            	    isLeft = true;
            	}
            	else if (Input.GetKey(KeyCode.RightArrow) && isLeft == true){
    	
            	    frontWheelAnimations.SetBool("leftTurn", false);
            	    frontWheelAnimations.SetBool("rightTurn", true);
            	    fullCarAnimations.SetBool("leftTurn", false);
            	    fullCarAnimations.SetBool("rightTurn", true);
    	
            	    frontWheelAnimations.SetBool("isDriving", true);
            	    bodyAnimations.SetBool("isDriving", true);
	
            	    turbo.SetBool("turnLeft", false);
            	    turbo.SetBool("turnRight", true);
    	
            	    isRight = true;
            	    isLeft = false;
            	}
            }
        }
    }

    void Update(){
    	if (scene.name == "Stage 2"){
           	Debug.Log(lane);
           	
           	if(Input.GetKeyDown(KeyCode.LeftArrow) && lane == 1){
           			lane=2;
           			fullCarAnimations.SetInteger("lane", 1);
           		}
           		else if(Input.GetKeyDown(KeyCode.LeftArrow) && lane == 2){
           			lane=3;
           			fullCarAnimations.SetInteger("lane", 2);
           		}
           		else if(Input.GetKeyDown(KeyCode.LeftArrow) && lane == 3){
           			lane=4;
           			fullCarAnimations.SetInteger("lane", 3);
           		}
           		else if(Input.GetKeyDown(KeyCode.RightArrow) && lane == 4){
           			lane=3;
					fullCarAnimations.SetInteger("lane", 4);
           		}
           		else if(Input.GetKeyDown(KeyCode.RightArrow) && lane == 3){
           			lane=2;
					fullCarAnimations.SetInteger("lane", -3);
           		}
           		else if(Input.GetKeyDown(KeyCode.RightArrow) && lane == 2){
           			lane=1;
					fullCarAnimations.SetInteger("lane", -2);
           		}
       	}	 
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "barrier"){
            Debug.Log("you crashed");
           crashed = true;
           Time.timeScale = 0.5f;
        }
    }
}
