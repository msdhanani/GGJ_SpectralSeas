using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string Scene_To_Load;
   
    private GameObject StoredObject;
    void Start()
    {
        
    }
    void Update()
    {
    }

   
public void LoadScenes()
    {
      
            
            SceneManager.LoadScene(Scene_To_Load);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void doExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}

