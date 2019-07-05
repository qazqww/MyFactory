using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    Dictionary<int, TableSetting> tableList = new Dictionary<int, TableSetting>();

    public void AddTable(int tableID, TableSetting table)
    {
        tableList.Add(tableID, table);
    }

    public T Create<T> (CharType charType, int index) where T : Component
    {
        Object obj = Create(charType, index);

        return obj as T;
    }

    // prefab 경로를 찾아서 instantiate한다. (리소스 경로, 테이블 모델명 필요)
    // charType에 따라 다른 경로를 찾는다.
    private Component Create(CharType charType, int index)
    {
        string path = string.Empty;
        string modelName = tableList[(int)charType].ToStr(index, "MODEL");

        switch(charType)
        {
            case CharType.HERO:
                path = "Hero/" + modelName; 
                break;
            case CharType.MONSTER:
                path = "Monster/" + modelName;
                break;
        }

        if (string.IsNullOrEmpty(path))
            return null;

        Component component = GameObject.Instantiate(Resources.Load(path)) as Component;
        // component.SendMessage("Init", SendMessageOptions.DontRequireReceiver);
        return component;
    }
}
