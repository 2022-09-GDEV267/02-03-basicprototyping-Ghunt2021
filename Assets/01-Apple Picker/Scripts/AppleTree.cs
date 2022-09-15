using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]

    // Prefab for instantiating apples

    public GameObject applePrefab;
    public GameObject applePrefabG;
    public GameObject applePrefabM;

    // Speed at which the AppleTree moves

    public float speed = 1f;



    // Distance where AppleTree turns around

    public float leftAndRightEdge = 10f;



    // Chance that the AppleTree will change directions

    public float chanceToChangeDirections = 0.1f;



    // Rate at which Apples will be instantiated

    public float secondsBetweenAppleDrops = 1f;

    public float chanceForRed = 0.7f;
    public float chanceForGreen = 0.5f;
    public float chanceForMold = 1f;



    void Start()
    {
        // Dropping apples every second

        Invoke("DropApple", 2f);
        // Dropping apples every second

    }

    void DropApple()
    {                                                  // b

        if (Random.value < chanceForRed)
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);      // c
            apple.transform.position = transform.position;                  // d
        }

        if (Random.value > chanceForRed && Random.value < chanceForGreen)
        { 
            GameObject apple = Instantiate<GameObject>(applePrefabG);      // c
            apple.transform.position = transform.position;                  // d
        }
        
        if (Random.value > chanceForRed && Random.value > chanceForGreen)
        {
        GameObject apple = Instantiate<GameObject>(applePrefabM);      // c
        apple.transform.position = transform.position;                  // d
        }

        Invoke("DropApple", secondsBetweenAppleDrops);                // e

    }

    void Update()
    {

        // Basic Movement

        Vector3 pos = transform.position;                  // b

        pos.x += speed * Time.deltaTime;                   // c

        transform.position = pos;                          // d

        if (pos.x < -leftAndRightEdge)
        {

            speed = Mathf.Abs(speed);  // Move right

        }
        else if (pos.x > leftAndRightEdge)
        {

            speed = -Mathf.Abs(speed); // Move left

        }
        else if (Random.value < chanceToChangeDirections)
        {        // a

            speed *= -1; // Change direction                           // b

        }

    }

    void FixedUpdate()
    {

        // Changing Direction Randomly is now time-based because of FixedUpdate()

        if (Random.value < chanceToChangeDirections)
        {                     // b

            speed *= -1; // Change direction

        }

    }


}