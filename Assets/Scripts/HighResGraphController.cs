using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighResGraphController : MonoBehaviour{

    [SerializeField]
    private List<Transform> spawnPoints;
    
    [SerializeField]
    private GameObject staticRiserPrefab;
    
    public static Action<int, List<Transform>> OnGenerateFinish;
    
    public GameObject Riser16Reference;
    
    [SerializeField]
    private List<Transform> riser16List;
    
    [SerializeField]
    private List<List<Transform>> riserRef;

    void Awake(){
        riserRef = new List<List<Transform>>();
        Riser16Controller.ToUpdateHighResGraphs += GenerateInitialGraphs;
    }
    
    void GenerateInitialGraphs(){
        for(int spPoint=0; spPoint<spawnPoints.Count; ++spPoint){
            // scale: -4 to 4
            
            int riserCount = (int)Mathf.Pow(2, spPoint + 5);
            float scale = (float)8 / riserCount;

            var riserScaled = Instantiate(staticRiserPrefab);
            riserScaled.transform.localScale = new Vector3(scale, 8, 1);
            
            Vector3 currPos = spawnPoints[spPoint].position;

            float leftMostPos = scale*(riserCount/2);
            for(int Ptr=0; Ptr<riserCount; ++Ptr){
                Instantiate(riserScaled, new Vector3(currPos.x, currPos.y, currPos.z + (scale/2) + scale * Ptr), staticRiserPrefab.transform.rotation, spawnPoints[spPoint]);
            }

            
            List<Transform> generatedRisers = new List<Transform>();
            for(int i=0; i<spawnPoints[spPoint].childCount; ++i){
                generatedRisers.Add(spawnPoints[spPoint].GetChild(i));
            }
            
            riserRef.Add(generatedRisers);
        }

        for(int i=0; i<Riser16Reference.transform.childCount; ++i){
            riser16List.Add(Riser16Reference.transform.GetChild(i));
        }
        
        InterpolateGraphs(); // after generating initial graphs positions
    }
    
    void InterpolateGraphs(){
        riserRef.Insert(0, riser16List);
        
        Debug.Log(riserRef.Count);
        
        for(int i=1; i<riserRef.Count; ++i){ // reverse anything after index 1(index 0, which is riser16List, already counts 0->16 in +x position)
            riserRef[i].Reverse();
        }
        
        for(int i=1; i<riserRef.Count; ++i){ // (16), 32, 64, 128, 256

            List<Transform> current = riserRef[i];
            List<Transform> previous = riserRef[i-1];

            for(int e=0; e<current.Count; e+=2){
                Vector3 newPos = current[e].position;
                newPos.y = previous[ Mathf.FloorToInt((float)e/2) ].position.y;
                current[e].position = newPos; 
                Debug.Log(e);
            }

            for(int offset=1; offset<current.Count/16; ++offset){
                for(int e=offset; e<current.Count-1; e+=2){
                    Vector3 newPos = current[e].position;
                    newPos.y = (float)(current[e-1].position.y + current[e+1].position.y) / 2;
                    current[e].position = newPos; 
                    Debug.Log(e);
                }
            }
            
            // current[current.Count - 1].transform.position = current[current.Count - 2].transform.position * (float)3/5;

            Debug.Log("");

        }
    }

}
