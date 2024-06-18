using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UiManager : MonoBehaviour
{
    public Image lifeBar;
    public Image[] hearts;
    public float valor;
    public static UiManager Instance;

    public CanvasGroup pausePanel;

    public RectTransform bounce;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        DOTween.Init();
        Expandir();
        
    }

    public void Expandir()
    {
        bounce.DOScale(1.2f, 0.25f).SetEase(Ease.InOutElastic).OnComplete(Achicar).SetId("Corazon");
    }
    public void Achicar()
    {
        bounce.DOScale(1, 0.25f).SetEase(Ease.InOutElastic).OnComplete(Expandir).SetId("Corazon");
    }


    public void ShowPanelPause()
    {
        pausePanel.gameObject.SetActive(true);
        pausePanel.GetComponent<RectTransform>().DOAnchorPosY(0, 1f);
        
    }
    public void HidePanelPause()
    {
        pausePanel.GetComponent<RectTransform>().DOAnchorPosY(1000, 1f).OnComplete(() => pausePanel.gameObject.SetActive(false));
    }

    public void UpdateLife(float currentLife, float lifeMax)
    {
        lifeBar.fillAmount = currentLife / lifeMax;
    }

    public void UpdateLifeHeart(int currentLife)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < currentLife);
        }
    }
}
