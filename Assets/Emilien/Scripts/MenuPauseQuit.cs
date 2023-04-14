using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseQuit : MonoBehaviour
{
    public void Quit() {
        SceneManager.LoadScene("Main Menu");
    }
}
