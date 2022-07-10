using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour {


	void Start () {
		
	}
	
	void Update () {
        MoveForward();

    }

    void MoveForward()
    {
        if(Input.GetKey ("a"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, -2);
        }
        if (Input.GetKey("d"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, 2);
        }
        if (Input.GetKey("w"))
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * 10;
        }
    }




}
