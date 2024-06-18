using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEscena : MonoBehaviour
{
    public Slider sliderBar;
    public Image imageBar;
    AsyncOperation operation;



    public void Update()
    {
    
    }

    public void LoadScene(string nameScene)
    {
        StartCoroutine(Charge(nameScene));
    }


    IEnumerator Charge(string scene)
    {
        operation = SceneManager.LoadSceneAsync(scene);
        

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            sliderBar.value = progress;
            imageBar.fillAmount = progress;
          
            yield return null;
        }

    }
}
