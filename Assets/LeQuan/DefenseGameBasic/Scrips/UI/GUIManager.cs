using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LQ.DefenseBasic;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public Dialog _gameOverDialog;
    [SerializeField] private GameObject homeGUI;
    [SerializeField] private GameObject gameGUI;
    [SerializeField] private TextMeshProUGUI mainCoinTxt;
    [SerializeField] private TextMeshProUGUI gameplayCointTxt;

    public void ShowGameGUI(bool isShow)
    {
        if(gameGUI) gameGUI.SetActive(isShow);
        if(homeGUI) homeGUI.SetActive(!isShow);
    }

    public void UpdateMainCoins()
    {
        if(mainCoinTxt) mainCoinTxt.text = Pref.coins.ToString();
    }

    public void UpdateGameplayCoins()
    {
        if (gameplayCointTxt) gameplayCointTxt.text = Pref.coins.ToString();
    }
}
