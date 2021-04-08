using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
	Node[] pathNode;
	public GameObject carContainer;
	public float moveSpeed = 50.0f;
	public float timer;
	public int currentNode;
	static Vector3 currentPositionHolder;
    // Start is called before the first frame update
    void Start()
    {
        pathNode = GetComponentsInChildren<Node>();
        CheckNode();

        foreach(Node n in pathNode){
        	Debug.Log(n.name);
        }

    }

    // Update is called once per frame
    void Update()
    {
    	// Debug.Log(currentNode);
        timer += Time.deltaTime * moveSpeed;

        if(carContainer.transform.position != currentPositionHolder){
        	carContainer.transform.position = Vector3.Lerp(carContainer.transform.position, currentPositionHolder, timer);
        }
        else{
        	if(currentNode < (pathNode.Length - 1)){
        		currentNode++;
        		CheckNode();
        	}
        }
    }

    void CheckNode(){
    	if(currentNode < (pathNode.Length - 1)){
    		timer = 0;
    		currentPositionHolder = pathNode[currentNode].transform.position;
    	}
    	
    }
}
