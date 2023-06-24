using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 14.0f;

    public float lowBound = 0;
    public float highBound = 5.0f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // SECTION keeps the player in bounds
        if(transform.position.x < -xRange) 
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } 
        
        if(transform.position.x > xRange) 
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.z < lowBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowBound);
        }

        if(transform.position.z > highBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, highBound);
        }
        // SECTION end

         horizontalInput = Input.GetAxis("Horizontal");
         transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

         verticalInput = Input.GetAxis("Vertical");
         transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // how to make something happen when Spacebar is pressed
         if(Input.GetKeyDown(KeyCode.Space))
         {
            // launches prefab pizza from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
         }
    }
}
