using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisableHandColliders : MonoBehaviour
{
    // set this variable by checking "use reference" and then search "select value"
    public InputActionProperty gripAnimationAction;

    private bool collidersEnabled = false;
    // set this variable on select for ray and grab interact 
    private bool isHoldingObject = false;

    private Collider[] handColliders;
    // Start is called before the first frame update
    void Start()
    {
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void DisableColliders() {
        foreach (Collider c in handColliders) {
            c.enabled = false;
        }
    }

    public void EnableColliders() {
        foreach (Collider c in handColliders) {
            c.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if grip val is near 1, then hand is in fist
        
        float gripVal = gripAnimationAction.action.ReadValue<float>();
        // if hand is in fist position and is not holding object, then enable colliders. otherwise disable colliders


    }
}
