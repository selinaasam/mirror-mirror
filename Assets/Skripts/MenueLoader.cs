using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueLoader : MonoBehaviour
{
    void OnEnable()
    {
        // only loads specific scene
        SceneManager.LoadScene("menue", LoadSceneMode.Single);
    }
}