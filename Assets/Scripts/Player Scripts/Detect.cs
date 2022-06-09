using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect: MonoBehaviour{

    public Canvas crosshair;

    private IInteractable clickedItem;

    private void FixedUpdate() {
        DetectHit();
    }

    private void Update() {
        HandleClick();
    }


    void HandleClick() {
        if(Input.GetMouseButtonDown(0)) {
            if(clickedItem != null){
                clickedItem.Use();
            }
        }
    }

    void DetectHit() {
        RaycastHit hit;
        GameObject objectDetected;
        if (Physics.Raycast(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
            objectDetected = hit.transform.gameObject;

            clickedItem = objectDetected.GetComponentInParent<IInteractable>();


            ActivateCrosshair(hit);

            return;
        }

        // Default to no crosshair
        objectDetected = null;
    }


    void ActivateCrosshair(RaycastHit hit){
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        crosshair.transform.position = hit.point - crosshair.transform.forward * 0.5f;
    }
}
