using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharType
{
    HERO,
    MONSTER
}

public class CharMng
{
    Factory factory;
    public void SetFactory (Factory factory) { this.factory = factory; }

    static CharMng instance = new CharMng();
    public static CharMng Instance
    {
       get
       {
            if(instance == null)
            {
                GameObject obj = new GameObject(typeof(CharMng).Name, typeof(CharMng));
                instance = obj.GetComponent<CharMng>();
            }
            return instance;
       }
    }

    public void Create(CharType charType, int index)
    {
        factory.Create<BaseChar>(charType, index);
    }

    void Init()
    {

    }
}
