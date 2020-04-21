using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStates : MonoBehaviour
{
    public enum State
    {
        Green,
        Yellow,
        Red,
    }

    public State state;

    public float timer = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        var ObjRenderer = GetComponent<Renderer>();

        int randomState = Random.Range(0, 3);
        switch(randomState)
        {
            case 0:
                ObjRenderer.material.SetColor("_Color", Color.green);
                state = State.Green;
                timer = Random.Range(5f, 10f);
                break;
            case 1:
                ObjRenderer.material.SetColor("_Color", Color.yellow);
                state = State.Yellow;
                timer = 4f;
                break;
            case 2:
                ObjRenderer.material.SetColor("_Color", Color.red);
                state = State.Red;
                timer = Random.Range(5f, 10f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }

    void ChangeState()
    {
        var ObjRenderer = GetComponent<Renderer>();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            switch (state)
            {
                case State.Green:
                    state = State.Yellow;
                    ObjRenderer.material.SetColor("_Color", Color.yellow);
                    timer = 4f;
                    break;
                case State.Yellow:
                    state = State.Red;
                    ObjRenderer.material.SetColor("_Color", Color.red);
                    timer = Random.Range(5f, 10f); 
                    break;
                case State.Red:
                    state = State.Green;
                    ObjRenderer.material.SetColor("_Color", Color.green);
                    timer = Random.Range(5f, 10f);
                    break;
            }
        }
    }

    /*
    void Green()
    {
        var ObjRenderer = GetComponent<Renderer>();
        ObjRenderer.material.SetColor("_Color", Color.green);

        StartCoroutine(Timer(4.0f, State.Yellow));
    }

    void Yellow()
    {
        var ObjRenderer = GetComponent<Renderer>();
        ObjRenderer.material.SetColor("_Color", Color.yellow);

        StartCoroutine(Timer(4.0f, State.Red));
    }

    void Red()
    {
        var ObjRenderer = GetComponent<Renderer>();
        ObjRenderer.material.SetColor("_Color", Color.red);

        StartCoroutine(Timer(4.0f, State.Green));
    }

   
    IEnumerator Timer(float time, State stateNew)
    {
        yield return new WaitForSeconds(time);
        state = stateNew;
    }
    */
    
}
