using System.Collections;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;
    //change for test


    void Awake()
    {

        Transform launchPointTrans = transform.Find("LaunchPoint");              // a

        launchPoint = launchPointTrans.gameObject;

        launchPoint.SetActive(false);                                          // b

    }

    void OnMouseEnter()
    {

        //print("Slingshot:OnMouseEnter()");

        launchPoint.SetActive(true);

    }



    void OnMouseExit()
    {

        //print("Slingshot:OnMouseExit()");

        launchPoint.SetActive(false);


    }



}