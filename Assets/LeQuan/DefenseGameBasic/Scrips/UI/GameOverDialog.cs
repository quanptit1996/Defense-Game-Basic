using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using LQ.DefenseBasic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverDialog : Dialog
{
    [SerializeField] private TextMeshProUGUI bestScore;

    [SerializeField] private Button btn_Quit;
    [SerializeField] private Button btn_RePlay;


    private void Start()
    {
        btn_Quit.onClick.AddListener(QuitGame);
        btn_RePlay.onClick.AddListener(RePlay);
    }

    public override void ShowHide(bool active)
    {
        base.ShowHide(active);

        if (bestScore) bestScore.text = Pref.bestScore.ToString("0000");
    }

    public void RePlay()
    {
        ShowHide(false);
        SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
