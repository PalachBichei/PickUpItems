using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button m_Restart;
    [SerializeField] private CanvasGroup FadePanel;

    private void Start()
    {
        FadePanel.DOFade(0, 1).OnComplete((() =>
        {
            FadePanel.gameObject.SetActive(false);
        }));
        m_Restart.onClick.AddListener(Restart);
    }

    public void Restart()
    {
        FadePanel.gameObject.SetActive(true);
        FadePanel.DOFade(1, 1).OnComplete((() =>
        {
            SceneManager.LoadScene(0);
        }));
    } 
}
