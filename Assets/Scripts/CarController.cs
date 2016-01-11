using UnityEngine;
using System.Collections;
using System;

public class CarController : MonoBehaviour {
    public float enginePower = 50;
    public float maxSteer = 2;
    public float enginePitch=0;
    public float power;
    private float steer;
    public float gearMinValue = 0.0f;
    public float gearMaxValue = 0.0f;

    private AudioSource audio;

    public int[] gearRatio ;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
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
        enginePitch = (float)(0.5 + ((-1*power) / enginePower));
        audio.pitch = enginePitch;
    }
}
