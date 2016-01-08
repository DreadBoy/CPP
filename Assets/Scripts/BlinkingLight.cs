using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class BlinkingLight : MonoBehaviour {

    new Light light;

    public float onTime = 0.9f;
    public float offTime = 0.6f;

    private float rand;
    IEnumerator Start()
    {
        light = GetComponent<Light>();
        rand = UnityEngine.Random.Range(0.7f, 1.3f);
        yield return new WaitForSeconds(UnityEngine.Random.value);
        while (true)
        {
            light.enabled = true;
            yield return new WaitForSeconds(onTime * rand);
            light.enabled = false;
            yield return new WaitForSeconds(offTime * rand);
        }
    }
}
