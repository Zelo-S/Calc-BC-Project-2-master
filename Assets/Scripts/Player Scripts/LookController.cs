using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour{

    public Transform camPos;
    private float Sens = 100;
    private float xRot = 0;
    private float yRot = 0;
    private float camDist = 5;
    [SerializeField]
    private static bool isLookActive;
    
    void Awake(){
        Cursor.lockState = CursorLockMode.Locked;
        isLookActive = true;
        HandlePlayerState.OnHandleControls += HandleLook;
    }
    
    void Update(){
        if(isLookActive) MoveCamera();
    }

    private void MoveCamera() {
        float xInput = Input.GetAxis("Mouse X") * Time.deltaTime * Sens;
        float yInput = Input.GetAxis("Mouse Y") * Time.deltaTime * Sens;

        xRot += -1 * yInput;
        yRot += xInput;


        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.eulerAngles = new Vector3(xRot, yRot, 0);

        transform.position = camPos.position;
    }
    
    void HandleLook(bool state){
        if(state == true) Cursor.lockState = CursorLockMode.Locked; // player is active, prompt not open
        else Cursor.lockState = CursorLockMode.None; // player is inactive, prompt open
        isLookActive = state;
    }

}
