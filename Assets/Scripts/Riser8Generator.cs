using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Riser8Generator : MonoBehaviour{
    
    [SerializeField]
    private List<GameObject> referenceRisers;
    
    [SerializeField]
    private List<GameObject> interpolateRisers;
    
    public static Action OnRise;
    
    void Awake(){
        ConfirmButtonController.OnConfirmButton += UpdatePositions;
    }

    public void UpdatePositions(){
        for(int i=0; i<interpolateRisers.Count; i+=2){
            Vector3 newPosY = interpolateRisers[i].transform.position;
            newPosY.y = referenceRisers[ (int)Mathf.Floor((float)i/2) ].transform.position.y;
            interpolateRisers[i].transform.position = newPosY;
        }
        
        for(int i=1; i<interpolateRisers.Count-1; i+=2){
            Vector3 newInterY = interpolateRisers[i].transform.position;
            newInterY.y = ( interpolateRisers[i-1].transform.position.y + interpolateRisers[i+1].transform.position.y ) / 2;
            interpolateRisers[i].transform.position = newInterY;
        }
        
        int last = interpolateRisers.Count-1;
        Vector3 newLastY = interpolateRisers[last].transform.position;
        newLastY.y = ( interpolateRisers[last-1].transform.position.y ) / 2;
        interpolateRisers[last].transform.position = newLastY;
        
        OnRise?.Invoke();
    }

}
