using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphInterpolateController : MonoBehaviour{
    
    [SerializeField]
    private int controllerNumber;

    void Awake(){
        HighResGraphController.OnGenerateFinish += InterpolateGraphs;
    }    

    void InterpolateGraphs(int controllerNumber, List<Transform> generatedRisers){
        if(this.controllerNumber == controllerNumber){
            for(int i=0; i<generatedRisers.Count; ++i){
                
            }

        }
    }

}
