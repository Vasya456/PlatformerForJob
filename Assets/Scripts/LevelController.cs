using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;


    private void Awake()
    {
        instance = this;
    }

   
    public void SpawnRespawn()
    {
        SceneManager.LoadScene(0);
    }
   
    
}
