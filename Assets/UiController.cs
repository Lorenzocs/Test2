using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    public GameObject panelPrincipal;
    public GameObject panelCredits;
    public GameObject panelOptions;

    public GameObject panelCarga;

    void Start()
    {
        GoToMenu();
    }

    public void GoToMenu()
    {
        panelPrincipal.SetActive(true);
        panelCredits.SetActive(false);
        panelOptions.SetActive(false);
        panelCarga.SetActive(false);
    }

    public void GoToOptions()
    {
        panelPrincipal.SetActive(false);
        panelCredits.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void GoToCredits()
    {
        panelPrincipal.SetActive(false);
        panelCredits.SetActive(true);
        panelOptions.SetActive(false);
    }

    public void Play()
    {
        panelCarga.SetActive(true);
        panelPrincipal.SetActive(false);
    }

}
