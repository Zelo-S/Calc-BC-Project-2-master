using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private float movementSpeed = 15.0f; // lower number later: 5/25/22
    private float rotateSpeed = 0.06f;
    private float jumpForce = 30.0f;
    private Rigidbody rb;

    public Transform camFace;
    
    private bool isMovmentActive;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        isMovmentActive = true;
        HandlePlayerState.OnHandleControls += HandleMovements;
    }

    void Update() {
        if(isMovmentActive){
            PlayerRotation();
            PlayerMovement();
        }
    }

    private void FixedUpdate() {
        if(isMovmentActive){
            // PlayerJump();
        }
    }
    
    void PlayerMovement() {
        float inputForward = Input.GetAxis("Vertical");
        float inputSide = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(inputSide, 0, inputForward) * Time.deltaTime * movementSpeed);

    }
    void PlayerJump() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    void PlayerRotation() {
        Quaternion previous = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(0, camFace.eulerAngles.y, 0);

        transform.rotation = Quaternion.Lerp(previous, newRotation, rotateSpeed);
    }
    
    void HandleMovements(bool state){
        isMovmentActive = state;
    }
}
