using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
	public Canvas pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPauseMenu(){
    	pauseScreen.enabled = true;
    	Time.timeScale = 0.0f;
    }

    public void ClosePauseMenu(){
    	pauseScreen.enabled = false;
    	Time.timeScale = 1.0f;
    }

    public void GoToMenu(){
    	SceneManager.LoadScene("MainMenu");
    }
}
