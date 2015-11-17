using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Power: " + CarStats.speed + "\nSteer: " + CarStats.steer;
	}
}

public static class CarStats
{
    public static float speed;
    public static float steer;
}