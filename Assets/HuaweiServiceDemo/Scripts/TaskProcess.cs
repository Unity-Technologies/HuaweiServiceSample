using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskProcess : MonoBehaviour
{
    public static LinkedList<Action> tasks = new LinkedList<Action>(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (tasks.Count > 0)
        {
            var t = tasks.First;
            tasks.RemoveFirst();
            t.Value();
        }
        
    }
}
