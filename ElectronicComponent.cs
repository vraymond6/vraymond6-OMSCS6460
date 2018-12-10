using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElectronicComponent: MonoBehaviour
{
    public static int currentId { get; set; }
    public int id { get; set; }

    public bool[] inputs;
    public bool[] outputs;

    public bool debug { get; set; }

    public void Start()
    {
        id = currentId;
        currentId++;

        debug = false;
    }

    public abstract void Update();
    public abstract void DebugComponent();
}
