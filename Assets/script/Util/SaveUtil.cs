using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUtil
{
    private string DeckName = "default";
    private List<EnumController.CardNo> DeckList = new List<EnumController.CardNo>();
    private static string filePath = @"./Save";

    public void Save()
    {
        if (Directory.Exists(filePath))
        {
            File.Delete(@"./Save/" + DeckName + ".txt");
            if(DeckList.Count == 0)
            {
                File.AppendAllText(@"./Save/" + DeckName + ".txt", "");
                return;
            }

            for(int i = 0; i < DeckList.Count; i++)
            {
                File.AppendAllText(@"./Save/" + DeckName + ".txt", Convert.ToString(DeckList[i]) + Environment.NewLine);
            }
        }
        else
        {
            Directory.CreateDirectory(filePath);
            if (DeckList.Count == 0)
            {
                File.AppendAllText(@"./Save/" + DeckName + ".txt", "");
                return;
            }

            for (int i = 0; i < DeckList.Count; i++)
            {
                File.AppendAllText(@"./Save/" + DeckName + ".txt", Convert.ToString(DeckList[i]) + Environment.NewLine);
            }
        }
    }

    public void SetDeckName(string DeckName)
    {
        this.DeckName = DeckName;
        return;
    }

    public void SetDeckList(List<EnumController.CardNo> DeckList)
    {
        this.DeckList = DeckList;
        return;
    }
}
