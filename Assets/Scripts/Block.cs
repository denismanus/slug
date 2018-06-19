using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {


    private string direction;
	// Use this for initialization
	void Start () {
		
	}

    public string  GetDirectionCreated()
    {
        return direction;
    }

    public void SetDirectionCreate(string direction)
    {
        this.direction = direction;
    }
}
