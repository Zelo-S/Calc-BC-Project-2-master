using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointController : MonoBehaviour{

    [SerializeField]
    private Canvas introductionScreen;
    
    void Awake(){
        introductionScreen.gameObject.SetActive(false);
    } 
    
    void OnMouseEnter(){
        introductionScreen.gameObject.SetActive(true);
    }

    void OnMouseExit(){
        introductionScreen.gameObject.SetActive(false);
    }

}
