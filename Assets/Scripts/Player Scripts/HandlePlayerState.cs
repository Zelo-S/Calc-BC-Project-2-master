using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandlePlayerState : MonoBehaviour{
    
    public static Action<bool> OnHandleControls;
    
    void Awake(){
        Menuable.OnOpenMenuHandlePlayer += HandleControls;    
    }    
    
    void HandleControls(bool state){
        OnHandleControls?.Invoke(state);
    }

}
