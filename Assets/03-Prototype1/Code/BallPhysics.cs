using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float velocityMult = 8f;

    public GameObject launchZone;

    public Vector3 launchPos;

    public bool aimingMode;

    public GameObject golfBall;

    private Rigidbody golfBallRigidbody;

    // Start is called before the first frame update

    void Awake()
    {
        Transform launchZoneTrans = transform.Find("LaunchZone");              // a

        launchZone = launchZoneTrans.gameObject;

        launchZone.SetActive(false);

        launchPos = launchZoneTrans.position; // b

    }
    
    
    void Start()
    {
        
    }


    void OnMouseEnter()
    {

        //print("Slingshot:OnMouseEnter()");

        launchZone.SetActive(true);

    }



    void OnMouseExit()
    {

        //print("Slingshot:OnMouseExit()");

        launchZone.SetActive(false);


    }

    void OnMouseDown()
    {                                                    // d

        // The player has pressed the mouse button while over Slingshot

        aimingMode = true;

        // Start it at the launchPoint

        // projectile = Instantiate(prefabProjectile) as GameObject;

       // golfBall.transform.position = launchZone;

        // Set it to isKinematic for now

        golfBallRigidbody = golfBall.GetComponent<Rigidbody>();                // a

        golfBallRigidbody.isKinematic = true;                                    // a

    }

    // Update is called once per frame
    void Update()
    {

        // If Slingshot is not in aimingMode, don't run this code

        if (!aimingMode) return;                                                   // b



        // Get the current mouse position in 2D screen coordinates

        Vector3 mousePos2D = Input.mousePosition;                                  // c

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);



        // Find the delta from the launchPos to the mousePos3D

        Vector3 mouseDelta = mousePos3D - launchPos;

        // Limit mouseDelta to the radius of the Slingshot SphereCollider          // d

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if (mouseDelta.magnitude > maxMagnitude)
        {

            mouseDelta.Normalize();

            mouseDelta *= maxMagnitude;

        }




        // Move the projectile to this new position

        Vector3 projPos = launchPos + mouseDelta;

        golfBall.transform.position = projPos;



        if (Input.GetMouseButtonUp(0))
        {                                         // e

            // The mouse has been released

            aimingMode = false;

            golfBallRigidbody.isKinematic = false;

            golfBallRigidbody.velocity = -mouseDelta * velocityMult;

            FollowCam.POI = golfBall;



        }
    }
}
