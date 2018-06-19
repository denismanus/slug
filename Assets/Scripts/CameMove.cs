
using UnityEngine;

public class CameMove : MonoBehaviour {

    public GameObject Character;

	
	void Update () {

        transform.position = new Vector3(Character.transform.position.x, Character.transform.position.y, -10f);
		
	}
}
