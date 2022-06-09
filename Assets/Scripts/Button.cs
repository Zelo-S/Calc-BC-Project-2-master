using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Button : MonoBehaviour, IInteractable{
    
    [SerializeField]
    private Animator animator;
    

    public void Use(){
        AnimateButton();
        UseButton();
    }
    
    void AnimateButton(){
        animator.SetTrigger("pressButton");
    }
    
    public abstract void UseButton();
}
