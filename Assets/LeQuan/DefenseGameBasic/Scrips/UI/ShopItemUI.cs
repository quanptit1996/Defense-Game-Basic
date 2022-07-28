using System.Collections;
using System.Collections.Generic;
using LQ.DefenseBasic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private Image hud;
    public Button btnBuy;

    public void UpdateUI(ShopItem item,int itemIndex)
    {
        if(item == null) return;

        if (hud)
        {
            hud.sprite = item.previewImg;
        }

        bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF+itemIndex);

        if (isUnlocked)
        {
            if (Pref.curPlayerId == itemIndex)
            {
                if (priceTxt)
                {
                    priceTxt.text = "Active";
                }
            }
            else if(priceTxt)
            {
                priceTxt.text = "Owned";

            }
        }
        else
        {
            if(priceTxt)  priceTxt.text = item.price.ToString();

        }
    }
}
