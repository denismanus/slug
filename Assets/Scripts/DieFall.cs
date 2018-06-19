using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFall : MonoBehaviour
{

    public GameObject respawn;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            other.transform.position = respawn.transform.position;
        }
    }
}
