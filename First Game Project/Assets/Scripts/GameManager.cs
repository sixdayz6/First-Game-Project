using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float difficulty = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }

    }
    public void _GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void _LevelOne()
    {
        difficulty = 10f;
    }

    public void _LevelTwo()
    {
        difficulty = 2f;
    }
}
