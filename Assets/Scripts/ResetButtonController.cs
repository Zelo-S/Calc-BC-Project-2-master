using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonController : Button{

    [SerializeField]
    private List<GameObject> risers;
    
    [SerializeField]
    private List<Vector3> startPositions;
    
    [SerializeField]
    private List<Transform> spawnPoints;
    
    
    void Awake(){
        foreach(var riser in risers) startPositions.Add(riser.transform.position);
    }

    public override void UseButton(){
        ResetPositions();         
    }
    
    public void ResetPositions(){
        for(int i=0; i<risers.Count; ++i){
            risers[i].transform.position = startPositions[i];
        }
        
        for(int i=0; i<spawnPoints.Count; ++i){
            Transform current_SP = spawnPoints[i];
            
            for(int e=current_SP.childCount-1; e>=0; --e){
                Destroy(spawnPoints[i].GetChild(e).gameObject);
            }
        }
    }
}

