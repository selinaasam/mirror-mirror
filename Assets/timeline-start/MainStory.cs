using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    void OnEnable()
    {
        // only loads specific scene
        SceneManager.LoadScene("room-kai", LoadSceneMode.Single);
    }
}
