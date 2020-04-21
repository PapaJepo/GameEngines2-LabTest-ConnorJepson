using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStates : MonoBehaviour
{
    private enum State
    {
        Green,
        Yellow,
        Red,
    }

    private State state;
    // Start is called before the first frame update
    void Start()
    {
        int randomState = Random.Range(0, 3);
        switch(randomState)
        {
            case 0:
                state = State.Green;
                break;
            case 1:
                state = State.Yellow;
                break;
            case 2:
                state = State.Red;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.Green:
                Green();
                break;
            case State.Yellow:
                Yellow();
                break;
            case State.Red:
                Red();
                break;
        }
    }

    void Green()
    {
        var ObjRenderer = GetComponent<Renderer>();
        ObjRenderer.material.SetColor("_Color", Color.green);

        StartCoroutine(Timer(2.0f, State.Yellow));
    }

    void Yellow()
    {
        var ObjRenderer = GetComponent<Renderer>();
        ObjRenderer.material.SetColor("_Color", Color.yellow);

        //StartCoroutine("YellowTimer");
        StartCoroutine(Timer(2.0f, State.Yellow));
    }

    void Red()
    {
        var ObjRenderer = GetComponent<Renderer>();
        ObjRenderer.material.SetColor("_Color", Color.red);

        //StartCoroutine("RedTimer");
        StartCoroutine(Timer(2.0f, State.Yellow));
    }

   /* IEnumerator GreenTimer()
    {
        float randomSec = Random.Range(5f, 10f);
        yield return new WaitForSeconds(5f);
        state = State.Yellow;
    }

    IEnumerator YellowTimer()
    {
        yield return new WaitForSeconds(4f);
        state = State.Red;
    }

    IEnumerator RedTimer()
    {
        float randomSec = Random.Range(5f, 10f);
        yield return new WaitForSeconds(5f);
        state = State.Green;
    }
    */
    IEnumerator Timer(float time, State stateNew)
    {
        yield return new WaitForSeconds(time);
        state = stateNew;
    }
    
}
