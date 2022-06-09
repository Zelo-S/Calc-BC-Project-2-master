using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiserController : MonoBehaviour{

    void Awake(){

    }

    public void RiseUp(){
        if(gameObject.transform.position.y >= 5){
            Debug.Log("No more rising!");
        }else{
            transform.Translate(new Vector3(0, 2, 0));
        }
    }

}
