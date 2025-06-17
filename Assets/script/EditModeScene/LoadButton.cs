using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    [SerializeField] CardInfoList m_CardInfoList;
    [SerializeField] DeckListManager m_DeckListManager;
    private string DeckName = "default";
    private static string filePath = @"./Save";

    public void onClick()
    {
        List<cardInfo> list = new List<cardInfo>();

        // ディレクトリがなければreturn
        if (!Directory.Exists(filePath) || !File.Exists(@"./Save/" + DeckName + ".txt"))
        {
            return;
        }

        IEnumerable<string> lines = File.ReadLines(@"./Save/" + DeckName + ".txt");

        // ファイルの行数分ループ
        foreach (string line in lines)
        {
            cardInfo temp = m_CardInfoList.Convert(line);
            if (temp != null)
            {
                list.Add(temp);
            }
            else
            {
                return;
            }
        }

        m_DeckListManager.cardInfoList = list;
        m_DeckListManager.sortDeckList();
        if (m_DeckListManager.isLevelSort)
        {
            m_DeckListManager.LevelSortDeckList();
        }
        if (m_DeckListManager.isColorSort)
        {
            m_DeckListManager.ColorSortDeckList();
        }
        m_DeckListManager.updateDeckList();
        // Debug.Log(File.ReadAllText(@"./Save/" + DeckName + ".txt"));
    }
}
