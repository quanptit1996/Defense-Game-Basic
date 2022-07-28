using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LQ.DefenseBasic;
using UnityEngine.UI;

public class ShopDialog : Dialog,IComponentChecking
{
   [SerializeField] private Transform gridRoot;
   [SerializeField] private ShopItemUI itemUIPrefab;

   public override void ShowHide(bool active)
   {
      base.ShowHide(active);
      Pref.coins = 100000;
     
      UpdateUI();
   }

   public bool IsComponentsNull()
   {
      return gridRoot == null;
   }

   private void UpdateUI()
   {
      if(IsComponentsNull()) return;
      ClearChilds();
      var items = ShopManager.Instance.items;
      if (items == null) return;
      {
         for (int i = 0; i < items.Length; i++)
         {
            
            int idx = i;
            var item = items[i];
            var itemUIClone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity);
            itemUIClone.transform.SetParent(gridRoot);
            itemUIClone.transform.localScale = Vector3.one;
            itemUIClone.transform.localPosition = Vector3.zero;
            
            itemUIClone.UpdateUI(item,i);

            if (itemUIClone.btnBuy)
            {
               itemUIClone.btnBuy.onClick.RemoveAllListeners();
               itemUIClone.btnBuy.onClick.AddListener(() => ItemEvent(item, idx));
            }
         }
      }
   }


   private void ItemEvent(ShopItem item, int itemIndex)
   {
      if (item == null) return;

      bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIndex);

      if (isUnlocked)
      {
         if (itemIndex == Pref.curPlayerId) return;

         Pref.curPlayerId = itemIndex;

         UpdateUI();
      }
      else if (Pref.coins >= item.price)
      {
         Pref.coins -= item.price;
         Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemIndex, true);
         Pref.curPlayerId = itemIndex;

         UpdateUI();


         GUIManager.Instance.UpdateMainCoins();

      }
      else
      {
         Debug.Log("Ban khong du tien");
      }

   }

   private void ClearChilds()
   {
      if(IsComponentsNull()) return;

      for (int i = 0; i < gridRoot.childCount; i++)
      {
         var child = gridRoot.GetChild(i);
         
         if(child)
            Destroy(child.gameObject);
      }
   }
   
}
