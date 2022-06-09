using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController: MonoBehaviour{
    
    [SerializeField]
    private bool isDoorActive;

    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    public GameObject button;
    
    void Start(){
        isDoorActive = false;
        animator.SetBool("isDoorOpened", false);
        if(button.GetComponent<DoorButtonController>() != null){
            button.GetComponent<DoorButtonController>().OnButtonClicked += OpenClose;
        }
        if(button.GetComponent<DoorCodeController>() != null){
            button.GetComponent<DoorCodeController>().OnButtonClicked += OpenClose;
        }
    }
    
    void OpenClose(){
        Debug.Log("Toggling Door");
        isDoorActive = !isDoorActive;
        animator.SetBool("isDoorOpened", isDoorActive);
        
        if(isDoorActive) Debug.Log("Open door...");
        else Debug.Log("Close door...");
    }
    
}