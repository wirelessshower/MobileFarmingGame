using System;
using UnityEngine;

public class ActionTester : MonoBehaviour
{
    public Action myAction;


    void Start()
    {
        myAction = DebugANumber;

        myAction();
    }

    private void DebugANumber(){
        Debug.Log("5");
    }

    private void DebugAString(){
        Debug.Log("Hello World");
    }
}
