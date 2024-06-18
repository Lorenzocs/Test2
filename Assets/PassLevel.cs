using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelCounter.Instance.currentLevel++;
        Invoke("VolverAMenu",5f);
    }

    public void VolverAMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
