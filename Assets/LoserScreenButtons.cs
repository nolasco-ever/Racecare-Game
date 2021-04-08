using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoserScreenButtons : MonoBehaviour
{
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel(){
    	SceneManager.LoadScene(scene.name);
    }

    public void GoToMainMenu(){
    	SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel(){
        if(scene.name == "Stage 1"){
            SceneManager.LoadScene("Stage 2");
        }
    }
}
