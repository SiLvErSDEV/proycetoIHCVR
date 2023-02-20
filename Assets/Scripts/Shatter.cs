using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{

    private bool exploding = false;
    public GameObject shatteredPrefab;
    // private void OnTriggerEnter(Collider other) {
    //     Instantiate(shatteredPrefab, transform.position, transform.rotation);
    //     Destroy(gameObject);
    // }

    private void OnCollisionEnter(Collision other) {

        Transform oldRockTransform = transform;
        Destroy(gameObject);

        if (exploding) {
            Debug.Log("tried to explode more than once");
            return;
        }
        exploding = true;
        GameObject explosion = Instantiate(shatteredPrefab, oldRockTransform.position, oldRockTransform.rotation);
        
        // Debug.Log(explosion);
        // Debug.Log(explosion.transform.GetComponentsInChildren<Transform>().Length);
        // Debug.Log(explosion.transform.childCount);

        
        

        foreach (Transform g in explosion.transform) {
            // Debug.Log(g.name);
            Rigidbody rb = g.GetComponent<Rigidbody>();
            // rb.AddExplosionForce(force, explosionPosition, explosionRadius, 0, )
            rb.AddExplosionForce(500f, oldRockTransform.position, 100f);
        }
        
        Destroy(explosion, 3);
    }
}
