using System.Collections;
using UnityEngine.SceneManagement; //библиотеки SceneManagement
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void Next()
    {
        SceneManager.LoadScene(1); //номер сцены в меню File -> Build Setting           

    }


}
