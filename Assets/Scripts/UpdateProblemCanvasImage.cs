using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProblemCanvasImage : MonoBehaviour{
    
    private Image imageUsed;
    
    void Awake(){
        DoorButtonController.OnProblemChosen += InitImage;
        imageUsed = GetComponent<Image>();
    }
    
    void InitImage(Level1Problems problem){
        imageUsed.sprite = problem.prompt;
    }

}
