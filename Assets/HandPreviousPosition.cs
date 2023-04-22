using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPreviousPosition : MonoBehaviour {

    private Vector3 previousPosition;
    private Vector3 currentPosition;

    void Start() {
        previousPosition = transform.position;
    }

    void FixedUpdate() {
        // Debug.Log("before: " + previousPosition);
        previousPosition = currentPosition;
        currentPosition = transform.position;
        // Debug.Log("after: " + previousPosition);
    }

    public Vector3 GetPreviousPosition() {
        return previousPosition;
    }
}