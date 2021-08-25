using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
   public void playbutton()
    {
        SceneManager.LoadScene("Genesis_3");

    }
    public void Quitbutton()
    {
        Application.Quit();
    }
}
