using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class DoorCodeController : Menuable, IInteractable{

    public Action OnButtonClicked;
    public Canvas prompt;

    [SerializeField]
    private bool isProblemSolved;
    private bool isPromptActive;
    
    [SerializeField]
    private TextMeshProUGUI resultText;
    
    [SerializeField]
    private FinalDoorCode doorCodeLevel1;
    
    void Awake(){
        isProblemSolved = false;
        isPromptActive = false;
        prompt.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
    }
    
    public void SubmitAnswer(TMP_InputField input){
        resultText.color = Color.white;
        resultText.gameObject.SetActive(true);
        
        string inputText = input.text;
        string codeText = doorCodeLevel1.ans;
        
        if(inputText.Equals(codeText)){
            resultText.text = "NICE! YOU PASS!";
            OnButtonClicked?.Invoke();
            Debug.Log("Opening door...");
        }else{
            resultText.color = Color.red;
            resultText.text = "WRONG! TRY AGAIN!";
        }
        
        StartCoroutine(waitSeconds());

    }
    
    IEnumerator waitSeconds(){
        yield return new WaitForSeconds(3.0f);
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
