using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 5.8f);
        DontDestroyOnLoad(transform.gameObject);
    }
   void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
