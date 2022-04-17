using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Switch : MonoBehaviour
{
    public GameObject player;
  
    private static bool playerExists;
    public GameObject Canvas;
    public static Scene_Switch instance;
    public GameObject Maincamera;
    // These are objects that wont be destroyed when the player travels to a new scene 
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
         instance = this;
       
        
       DontDestroyOnLoad(this.gameObject);
         DontDestroyOnLoad(Maincamera);
       
      
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(player);
         


        }
        else
        {
            Destroy(gameObject);
            Destroy(Canvas);
            
        }
    }

    // this function tells the script which scene to choose in the build scene area 
    public void switchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
