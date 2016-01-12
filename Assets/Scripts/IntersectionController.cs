using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntersectionController : MonoBehaviour
{

    //public List<Decision> corrrectDecisions = new List<Decision>();
    public List<Action> scenario = new List<Action>();

    bool[] inputs = new bool[4];
    
    public String currentScene;
    public String nextScene;
    public AudioClip crash;
    public AudioClip success;

    void Update()
    {

        //if(corrrectDecisions.Count == 0)
        //    return;
        if (scenario.Count == 0)
            return;

        inputs[0] = GetLeft();
        inputs[1] = GetRight();
        inputs[2] = GetStraight();
        inputs[3] = GetWait();

        //če ni nobenega inputa
        if (!inputs[0] && !inputs[1] && !inputs[2] && !inputs[3])
            return;

        if (inputs[(int)scenario[0].decision])
        {
            if (scenario[0].prop != null)
                scenario[0].prop.Move(scenario[0].direction);
            scenario.RemoveAt(0);
        }
        else
        {
            var source = gameObject.AddComponent<AudioSource>();
            source.clip = crash;
            source.Play();
            StartCoroutine(delayedLoad(3, currentScene));
        }


        if (scenario.Count == 0)
        {
            var source = gameObject.AddComponent<AudioSource>();
            source.clip = success;
            source.Play();
            StartCoroutine(delayedLoad(3, nextScene));
        }

    }


    public enum Decision
    {
        left,
        right,
        straight,
        wait
    }

    public enum Direction
    {
        left,
        right,
        straight
    }

    [Serializable]
    public class Action
    {
        public Decision decision;
        public Direction direction;
        public PropController prop;
    }

    bool GetLeft()
    {
        //return Input.GetAxis("Horizontal") < 0;
        return Input.GetKeyDown("left");
    }

    bool GetRight()
    {
        //return Input.GetAxis("Horizontal") > 0;
        return Input.GetKeyDown("right");
    }

    bool GetStraight()
    {
        //return Input.GetAxis("Vertical") < 0;
        return Input.GetKeyDown("up");
    }

    bool GetWait()
    {
        //return Input.GetAxis("Jump") > 0;
        return Input.GetKeyDown("space");
    }

    IEnumerator delayedLoad(float seconds, String scene)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }
}
