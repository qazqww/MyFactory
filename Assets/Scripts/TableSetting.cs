using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSetting
{
    // <index, <mainkey, element>>
    Dictionary<int, Dictionary<string, string>> tableDic = new Dictionary<int, Dictionary<string, string>>();

    public void Load(string path)
    {
        string text = Resources.Load<TextAsset>(path).ToString();

        string[] rows = text.Split('\n');

        for (int i = 0; i < rows.Length; i++)
            rows[i] = rows[i].Replace("\r", "");

        int rowCount = rows.Length;
        if (string.IsNullOrWhiteSpace(rows[rows.Length - 1]))
            rowCount--;

        string[] mainkey = rows[0].Split(',');

        for(int i=1; i<rowCount; i++)
        {
            string[] cols = rows[i].Split(',');
            int index = -1;
            int.TryParse(cols[0], out index);

            if (!tableDic.ContainsKey(index) && index != -1)
                tableDic.Add(index, new Dictionary<string, string>());

            for (int j = 1; j < cols.Length; j++)
                tableDic[index].Add(mainkey[j], cols[j]);
        }
    }

    public int ToInt(int index, string key)
    {
        if (tableDic.ContainsKey(index) && tableDic[index].ContainsKey(key))
        {
            int element;
            if (int.TryParse(tableDic[index][key], out element))
                return element;
        }
        return -1;
    }

    public float ToFloat(int index, string key)
    {
        if (tableDic.ContainsKey(index) && tableDic[index].ContainsKey(key))
        {
            float element;
            if (float.TryParse(tableDic[index][key], out element))
                return element;
        }
        return -1;
    }

    public string ToStr(int index, string key)
    {
        if (tableDic.ContainsKey(index) && tableDic[index].ContainsKey(key))
            return tableDic[index][key];
        return string.Empty;
    }
}
