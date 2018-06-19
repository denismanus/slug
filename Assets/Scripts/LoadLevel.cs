using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public int level;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            SceneManager.LoadScene(level);
        }
    }
}
