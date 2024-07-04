using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Map { MarioRoom, CyberBar };
[System.Serializable]
public class MapUI
{
    public GameObject obj;
    public Map map;

}
public class MapSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public MapUI[] maps;
    public int index = 0;
    private int preIndex = Int32.MaxValue;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changeMap();
    }
    public void increaseindex()
    {
        if (index < maps.Length - 1)
            index++;

        Debug.Log(index);
    }
    public void decreaseindex()
    {
        if (index > 0)
            index--;
        Debug.Log(index);
    }
    void changeMap()
    {
        if (index != preIndex)
        {
            for (int i = 0; i < maps.Length; i++)
            {
                if (i == index)
                {
                    maps[i].obj.SetActive(true);
                }
                else
                {
                    maps[i].obj.SetActive(false);
                }
            }
            preIndex = index;
            StaticData.currentMap = (Map)index;
            Debug.Log(StaticData.currentMap);
        }
    }
}
