using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LQ.DefenseBasic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseDialog : Dialog
{
   [SerializeField] private Button btn_Replay;
   [SerializeField] private Button btn_Resume;

   private void Start()
   {
      btn_Replay.onClick.AddListener(Replay);
      btn_Resume.onClick.AddListener(Resume);
   }

   public override void ShowHide(bool active)
   {
      if (active)
      {
         Time.timeScale = 0;
      }
      else
      {
         Time.timeScale = 1;
      }
      base.ShowHide(active);
   }

   public void Resume()
   {
      ShowHide(false);
   }

   public void Replay()
   {
      ShowHide(false);
      SceneManager.LoadScene(Const.GAMEPLAY_SCENE);

   }
}
