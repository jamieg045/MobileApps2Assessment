using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GamePersist>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
