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

   private ShopManager _shopM;
   private GameManager _gameM;
   

   public override void ShowHide(bool active)
   {
      base.ShowHide(active);
      _shopM = FindObjectOfType<ShopManager>();
      _gameM = FindObjectOfType<GameManager>();
   
      UpdateUI();
   }

   public bool IsComponentsNull()
   {
      return _shopM == null || _gameM == null || gridRoot == null;
   }

   private void UpdateUI()
   {
      if(IsComponentsNull()) return;
      ClearChilds();
      var items = _shopM.items;
      if (items == null) return;
      {
         for (int i = 0; i < items.Length; i++)
         {
            var item = items[i];
            var itemUIClone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity);
            itemUIClone.transform.SetParent(gridRoot);
            itemUIClone.transform.localScale = Vector3.one;
            itemUIClone.transform.localPosition = Vector3.zero;
            
            itemUIClone.UpdateUI(item,i);
         }
      }
   }

   private void ItemEvent(ShopItem item ,int itemIndex)
   {
      if (item == null) return;

      bool isUnlocked = Pref.GetBool(Const.CUR_PLAYER_ID_PREF +itemIndex);
      if (isUnlocked)
      {
         if (itemIndex == Pref.curPlayerId) return;
         Pref.curPlayerId = itemIndex;
         
         UpdateUI();
      }
      else if (Pref.coins <= item.price)
      {
         
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
