using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationalCircuit : MonoBehaviour {

    public List<Node> nodes;
    public List<Connection> connections;

    protected LoadManager lManager;
	// Use this for initialization
	public void Start ()
    {

        nodes = new List<Node>();

        lManager = GameObject.Find("Manager").GetComponent<LoadManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
