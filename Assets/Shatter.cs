using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{

    private bool exploding = false;

    private float velocityNeededToShatter = 4f;
    public GameObject shatteredPrefab;
    // private void OnTriggerEnter(Collider other) {
    //     Instantiate(shatteredPrefab, transform.position, transform.rotation);
    //     Destroy(gameObject);
    // }

    private void OnCollisionEnter(Collision other) {

        Debug.Log(other.gameObject.name);
        


        if (other.gameObject.CompareTag("right hand") || other.gameObject.CompareTag("left hand")) {

            Debug.Log("collided with hand");

            HandPreviousPosition hand = other.gameObject.GetComponent<HandPreviousPosition>();
            Vector3 previousPosition = hand.GetPreviousPosition();
            Vector3 velocity = (other.gameObject.transform.position - previousPosition) / Time.deltaTime;

            Debug.Log("velocity: " + velocity);
            // Debug.Log("position: " + other.gameObject.transform.position);
            // Debug.Log("prev position: " + previousPosition);
            // Debug.Log("delta time: " + Time.deltaTime);

            // print velocity magnitude and game object velocity magnitude
            Debug.Log("velocity magnitude: " + velocity.magnitude);
            Debug.Log("game object velocity magnitude: " + gameObject.GetComponent<Rigidbody>().velocity.magnitude);

            float relativeVelocity = (velocity - gameObject.GetComponent<Rigidbody>().velocity).magnitude;
            Debug.Log("Relative velocity: " + relativeVelocity);
            if (relativeVelocity > velocityNeededToShatter) {
                ShatterObject();
            }

        }
        else {

            // if object velocity is high enough, shatter
            if (other.relativeVelocity.magnitude > velocityNeededToShatter) {
                ShatterObject();
            }
        }

        // Debug.Log(other.relativeVelocity.magnitude);

        // also if object is hit by object with high enough velocity shatter
        // if (other.gameObject.GetComponent<Rigidbody>() != null) {
        //     Debug.Log(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
        //     if (other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3) {
        //         ShatterObject();
        //     }
        // }        
    }


    public void ShatterObject() {
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
            rb.AddExplosionForce(200f, oldRockTransform.position, 100f);
        }
        
        // dont put a timer on the destroy :D
        // Destroy(explosion, 3); 
    }
}
