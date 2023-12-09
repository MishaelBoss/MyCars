using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Sene : MonoBehaviour
{
    //public int Scene;

    public void GoToLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void Exit()
    {
        Application.Quit();
    }

    void Update()
    {
        //if (Input.GetKey("escape"))  // если нажата клавиша Esc (Escape)
       /* {
            Application.Quit();    // закрыть приложение
        }*/
    }
}
