using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningAnimation : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }
}
