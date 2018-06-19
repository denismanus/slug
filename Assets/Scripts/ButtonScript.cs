using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {


   
	// Use this for initialization
	void Start () {
		
	}

    [SerializeField]
    public GameObject[] objectsToActivate;


    void PressButton()
    {

    }

    void UnPressButton()
    {

    }

    
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Button_top"&& objectsToActivate!=null)
        {
            foreach(GameObject obj in objectsToActivate)
            {
                obj.GetComponent<IActivatable>().Activate(false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Button_top"&& objectsToActivate!=null)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.GetComponent<IActivatable>().Activate(true);
            }
        }
    }
}
