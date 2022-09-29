using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

	public int orbValue;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
	// Before rendering each frame..
	void Update()
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}

}