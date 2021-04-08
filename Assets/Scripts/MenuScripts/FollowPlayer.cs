using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    private Scene scene;

	public Transform player;
    public Transform playerStage2;
	private Vector3 offset;
	public static float xOffset = -1.55f;
    public static float zOffset = -10f;
    public static bool following;
    // Start is called before the first frame update
    void Start()
    {
        following = true;
        zOffset = -10f;

        scene = SceneManager.GetActiveScene();
    }
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(zOffset);
        if(following == true){
            if(scene.name == "Stage 1"){
                offset = new Vector3(xOffset,6.0f,zOffset);
                transform.position = player.position + offset;
            }
            else if(scene.name == "Stage 2"){
                offset = new Vector3(0.0f,6.0f,zOffset);
                transform.position = playerStage2.position + offset;
            }
        }
    }
}
