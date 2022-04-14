using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Switch : MonoBehaviour
{
    public GameObject player;
    
    public GameObject Canvas;
    public static Scene_Switch instance;
    // These are objects that wont be destroyed when the player travels to a new scene 
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(player);
        
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Canvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function tells the script which scene to choose in the build scene area 
    public void switchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
