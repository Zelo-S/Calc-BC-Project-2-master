using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfirmButtonController : Button{

    public static Action OnConfirmButton;

    public override void UseButton(){
        UpdateSmallerRisers();        
    }
    
    void UpdateSmallerRisers(){
        OnConfirmButton?.Invoke();
    }
    

}
