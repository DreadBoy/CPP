using UnityEngine;
using System.Collections;
using System;

public class CarController : MonoBehaviour {
    private float enginePower = 50;
    private float maxSteer = 2;
    private float power;
    private float steer;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime;
        steer = Input.GetAxis("Horizontal") * maxSteer;

        transform.Translate(transform.forward * power, Space.World);

        if (Math.Abs(power) > 0 && Math.Abs(steer) > 0)
        {
            var rot = Vector3.zero;
            rot.y += steer;
            transform.Rotate(rot);
        }

        CarStats.speed = power;
        CarStats.steer = steer;
    }
}
