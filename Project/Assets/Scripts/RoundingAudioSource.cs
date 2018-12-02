using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundingAudioSource : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        gameObject.transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}
