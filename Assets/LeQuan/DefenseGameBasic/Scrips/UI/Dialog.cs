using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LQ.DefenseBasic;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titileTxt;
    [SerializeField] private TextMeshProUGUI contentTxt;

    public virtual void ShowHide(bool active)
    {
        gameObject.SetActive(active);
    }

    public virtual void UpdateDialog(string title,string content)
    {
        if (titileTxt)
        {
            titileTxt.text = title;
        }

        if (contentTxt)
        {
            contentTxt.text = content;
        }
    }

    public virtual void UpdateDialog()
    {
        
    }
}
