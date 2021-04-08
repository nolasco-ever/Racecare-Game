using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public Animator playImage;
	public Animator playText;
	public Animator optionsImage;
	public Animator optionsText;
	public Animator quitImage;
	public Animator quitText;

    public void LoadPlayMenu(){
    	SceneManager.LoadScene("Stage 1");
    }

    public void LoadOptionsMenu(){
    	SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame(){

    }

    public void PlayPointerEnter(){
    	playImage.SetBool("hover", true);
    	playText.SetBool("hover", true);
    }

    public void PlayPointerExit(){
    	playImage.SetBool("hover", false);
    	playText.SetBool("hover", false);
    }

    public void OptionsPointerEnter(){
    	optionsImage.SetBool("hover", true);
    	optionsText.SetBool("hover", true);

    }

    public void OptionsPointerExit(){
    	optionsImage.SetBool("hover", false);
    	optionsText.SetBool("hover", false);
    }

    public void QuitPointerEnter(){
    	quitImage.SetBool("hover", true);
    	quitText.SetBool("hover", true);
    }

    public void QuitPointerExit(){
    	quitImage.SetBool("hover", false);
    	quitText.SetBool("hover", false);
    }
}
