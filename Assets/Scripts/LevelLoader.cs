using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour{
    public int intlevelToLoad;
    public string nameLevelToLoad;
    
    public bool useIntegerLoad;

    void OnTriggerEnter(Collider other){
        GameObject collidedPlayer = other.gameObject;
        Debug.Log(collidedPlayer);
        if(collidedPlayer.CompareTag("Player")){
            Debug.Log("Entering next level...");
            LoadLevel();
        }
    }
    
    void LoadLevel(){
        if(useIntegerLoad){
            SceneManager.LoadScene(intlevelToLoad);
        }else{
            SceneManager.LoadScene(nameLevelToLoad);
        }
    }
}
