using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private int playerCactusAvailable = 4;
    [SerializeField] private int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI cactiText;
    // Start is called before the first frame update
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameController>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();
        cactiText.text = playerCactusAvailable.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeCactus()
    {
        playerCactusAvailable--;
        cactiText.text = playerCactusAvailable.ToString();
    }

    public void ProcessCactiDeletion()
    {
        if(playerCactusAvailable > 1)
        TakeCactus();
        else
        ResetGameSession();
    }

    public void ResetGameSession()
    {
        FindObjectOfType<GamePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void AddToScore(int addPoint)
    {
        score += addPoint;
        scoreText.text = score.ToString();
        


    }

    public bool CanPlaceCactus()
    {
        return playerCactusAvailable > 0;
    }
}
