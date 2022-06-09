using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DoorButtonController: Menuable, IInteractable{

    public Action OnButtonClicked;
    public Level1Problems problem;
    public Canvas prompt;

    [SerializeField]
    private bool isProblemSolved;
    private bool isPromptActive;
    
    [SerializeField]
    private TextMeshProUGUI result;
    
    void Awake(){
        isProblemSolved = false;
        isPromptActive = false;
        prompt.gameObject.SetActive(false);
        result.gameObject.SetActive(false);
    }
    
    public void SubmitAnswer(string ans){
        if(ans.Equals(problem.ans)) { 
            isPromptActive = false; 
            Debug.Log("NICE!");
            isProblemSolved = true;
            DisablePrompt();
            
            OnButtonClicked?.Invoke();
        }else{
            Debug.Log("Wrong ans!"); // play error sound here?
            result.gameObject.SetActive(true);
            StartCoroutine(waitSeconds());
        }
    }

    IEnumerator waitSeconds(){
        yield return new WaitForSeconds(3.0f);
        result.gameObject.SetActive(false);
        DisablePrompt();
    }
    
    public void EnablePrompt(){
        HandlePlayer(false); // inactive
        isPromptActive = true;
        prompt.gameObject.SetActive(isPromptActive);
    }
    
    public void DisablePrompt(){ // pressed "X"
        HandlePlayer(true); // active player
        isPromptActive = false;
        prompt.gameObject.SetActive(isPromptActive);
    }
    
    public void Use(){
        if(!isProblemSolved){ // if problem is solved, button unusable
            EnablePrompt();
        }
        else if(isProblemSolved){
            OnButtonClicked?.Invoke();
        }
    } 

}
