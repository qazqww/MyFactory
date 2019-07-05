using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    TableSetting table = new TableSetting();
    Factory factory = new Factory();

    void Start()
    {
        table.Load("CharTable");
        factory.AddTable((int)CharType.HERO, table);

        CharMng.Instance.SetFactory(factory);
        CharMng.Instance.Create(CharType.HERO, 1);
    }

    void Update()
    {
        
    }
}
/*
 CharMng Instance => Factory Create(캐릭터 타입, 테이블ID)
    */