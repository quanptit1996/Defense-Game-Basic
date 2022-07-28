using System;
using System.Collections;
using System.Collections.Generic;
using LQ.DefenseBasic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }

    public ShopItem[] items;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
        }
 
        Instance = this;
       // DontDestroyOnLoad( this.gameObject );
    }

    void Start()
    {
        Init();
    }

    private void Init()
    {
        if (items != null )
        {
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                string dataKey = Const.PLAYER_PREFIX_PREF+i; //player_0   player_1  player_2
                if (item != null)
                {
                    if (i == 0)
                    {
                        Pref.SetBool(dataKey,true);
                    }
                    else
                    {
                        if (!PlayerPrefs.HasKey(dataKey))
                        {
                            Pref.SetBool(dataKey,false);
                        }
                    }
                }
            }
        }
    }
}
