using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //STATIC Gamemanager Singleton makes this Gamemanager Class invocable once alone.
    public static GameManager singleton;

    // All tHE GroundPiece stored in this array
    private GroundPiece[] allGroundPiece;
  

    void Start()
    {
        SetupNewLevel();
    }

    private void SetupNewLevel()
    {
        allGroundPiece = FindObjectsOfType<GroundPiece>();
    }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += onLevelFinishedLoading;
    }

    private void onLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
    }

    public void CheckComplete()
    {
        bool isFinished = true;

        for(int i =0;  i < allGroundPiece.Length; i++)
        {
            if(allGroundPiece[i].isColored == false)
            {
                isFinished = false;
                break;
            }

            if (isFinished)
            {
                //Next Level
                NextLevel();
            }
        }
    }

    
    private void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
}
