using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Character { Jeff, Rick };


[System.Serializable]
public class CharacterUI
{
    public GameObject obj;
    public Character character;

}
public class CharacterSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterUI[] arr;
    public int index = 0;
    private int preIndex = Int32.MaxValue;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changeCharacter();
    }
    public void increaseindex()
    {
        if (index < arr.Length - 1)
            index++;

        Debug.Log(index);
    }
    public void decreaseindex()
    {
        if (index > 0)
            index--;
        Debug.Log(index);
    }
    void changeCharacter()
    {
        if (index != preIndex)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == index)
                {
                    arr[i].obj.SetActive(true);
                }
                else
                {
                    arr[i].obj.SetActive(false);
                }
            }
            preIndex = index;
            StaticData.currentPlayer = arr[index].character;
            Debug.Log(StaticData.currentPlayer);
        }
    }
}
