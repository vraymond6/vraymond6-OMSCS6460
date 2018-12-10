using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : ElectronicComponent
{
    public int timer;
    public new void Start()
    {
        timer = 60;
        outputs = new bool[1];
        outputs[0] = false;
        base.Start();
    }

    public override void Update()
    {
        timer--;
        if(timer == 0)
        {
            outputs[0] = !outputs[0];
            timer = 60;
        }
        
        if (debug)
        {
            DebugComponent();
        }
    }

    public override void DebugComponent()
    {
        if (outputs != null)
        {
            string message = "";
            message += "\nOutputs: ";
            foreach (bool output in outputs)
            {
                message += " " + output;
            }
            Debug.Log(message);
        }
    }
}
