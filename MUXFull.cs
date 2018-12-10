using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUXFull : CombinationalCircuit {

	// Use this for initialization
	new void Start ()
    {
      
        base.Start();
       
        //Nodes
        nodes.Add(Instantiate(lManager.findNode("ToggleInputNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));
        nodes.Add(Instantiate(lManager.findNode("ToggleInputNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));
        nodes.Add(Instantiate(lManager.findNode("ToggleInputNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));

        nodes.Add(Instantiate(lManager.findNode("NotNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));

        nodes.Add(Instantiate(lManager.findNode("AndNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));
        nodes.Add(Instantiate(lManager.findNode("AndNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));

        nodes.Add(Instantiate(lManager.findNode("OrNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));

        nodes.Add(Instantiate(lManager.findNode("LightOutputNode"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));
        
        for(int x=0;x<nodes.Count;x++)
        {
            nodes[x].transform.parent = transform;
        }
        
        //Connections
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
