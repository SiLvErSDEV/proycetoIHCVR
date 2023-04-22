using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPreviousPosition : MonoBehaviour {

    private Vector3 previousPosition;

    void Start() {
        previousPosition = transform.position;
    }

    void FixedUpdate() {
        Debug.Log("before: " + previousPosition);
        previousPosition = transform.position;
        Debug.Log("after: " + previousPosition);
    }

    public Vector3 GetPreviousPosition() {
        return previousPosition;
    }
}