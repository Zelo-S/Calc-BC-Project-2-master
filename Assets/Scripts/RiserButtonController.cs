using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RiserButtonController : Button{
    
    [SerializeField]
    private RiserController riser;
    
    public override void UseButton(){
        TransformRiser();
    }
    
    void TransformRiser(){
        riser.RiseUp();
    }
    

}
