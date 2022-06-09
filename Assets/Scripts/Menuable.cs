using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Menuable : MonoBehaviour{
    
    public static Action<bool> OnOpenMenuHandlePlayer;    
    
    public void HandlePlayer(bool state){ // active / inactive
        OnOpenMenuHandlePlayer?.Invoke(state);
    }

}
