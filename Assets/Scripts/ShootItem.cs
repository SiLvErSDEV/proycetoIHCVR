using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour
{

    public GameObject itemPrefab;

    private float throwSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.transform.position;
        // if left click
        if (Input.GetMouseButtonDown(0)) {
            GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity);
            Rigidbody itemRB = newItem.GetComponent<Rigidbody>();

            Vector3 cameraLook = Camera.main.transform.TransformDirection(Vector3.forward);

            itemRB.velocity = cameraLook * throwSpeed;
        }
    }
}
