using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorNiveles : MonoBehaviour
{
    public Button[] buttonsLevels;
    void Start()
    {
        for (int i = 0; i < buttonsLevels.Length; i++)
        {
            buttonsLevels[i].interactable = i < LevelCounter.Instance.currentLevel;
        }
    }


}
