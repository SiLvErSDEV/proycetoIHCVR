using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableHandColliders : MonoBehaviour
{

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
    // void Update()
    // {
        
    // }
}
