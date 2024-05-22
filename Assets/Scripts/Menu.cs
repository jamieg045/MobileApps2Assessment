using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //Loads the next scene in the index which is Scene 1 (Level 1) and this menu scene is Scene 0
        SceneManager.LoadSceneAsync(1);
    }
}
