using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public int currentLevel;

    public static LevelCounter Instance;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    public void Start()
    {
        if (currentLevel <= 0)
        {
            currentLevel = 1;
        }
    }
}
