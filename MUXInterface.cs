using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUXInteface : CombinationalCircuit {

	// Use this for initialization
	void Start ()
    {
        nodes.Add(lManager.findNode("ToggleInputNode"));
        nodes.Add(lManager.findNode("ToggleInputNode"));
        nodes.Add(lManager.findNode("ToggleInputNode"));

        nodes.Add(lManager.findNode("NotNode"));

        nodes.Add(lManager.findNode("AndNode"));
        nodes.Add(lManager.findNode("AndNode"));

        nodes.Add(lManager.findNode("OrNode"));

        nodes.Add(lManager.findNode("LightOutputNode"));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
