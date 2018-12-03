using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEffect : MonoBehaviour {

    public float speed;

    public float rotationSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = gameObject.transform.position;
        if (position.x < -600) {
            position.x = 800;
        }
        gameObject.transform.position = new Vector3(position.x - (Time.deltaTime * speed), position.y, position.z);
        //gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(1f, 0f, 0f), Time.deltaTime * speed);
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed, Space.World);
    }
}
