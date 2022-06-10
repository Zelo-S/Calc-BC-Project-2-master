using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonController : Button{

    [SerializeField]
    private List<GameObject> risers4;

    [SerializeField]
    private List<GameObject> risers8;

    [SerializeField]
    private List<GameObject> risers16;

    private List<Vector3> startPositions4;
    private List<Vector3> startPositions8;
    private List<Vector3> startPositions16;
    
    [SerializeField]
    private List<Transform> spawnPoints;
    
    public HighResGraphController highRes;
    
    
    void Awake(){
        startPositions4 = new List<Vector3>();
        startPositions8 = new List<Vector3>();
        startPositions16 = new List<Vector3>();
        foreach(var riser in risers4) startPositions4.Add(riser.transform.position);
        foreach(var riser in risers8) startPositions8.Add(riser.transform.position);
        foreach(var riser in risers16) startPositions16.Add(riser.transform.position);
    }

    public override void UseButton(){
        ResetPositions();         
    }
    
    public void ResetPositions(){
        for(int i=0; i<risers4.Count; ++i){
            risers4[i].transform.position = startPositions4[i];
        }
        for(int i=0; i<risers8.Count; ++i){
            risers8[i].transform.position = startPositions8[i];
        }
        for(int i=0; i<risers16.Count; ++i){
            risers16[i].transform.position = startPositions16[i];
        }
        
        for(int i=1; i<spawnPoints.Count; ++i){
            Transform current_SP = spawnPoints[i];
            
            for(int e=current_SP.childCount-1; e>=0; --e){
                Destroy(spawnPoints[i].GetChild(e).gameObject);
            }
        }
        
        highRes.WipeList();
        Debug.Log("Wiped list!");
    }
}

