using System;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    private static Text recordText; // everyone has the same text
    private static int record = 0;

    // Use this for initialization
    internal void Start()
    {
        recordText = GetComponent<Text>();
        UpdateBestText();
    }

    public static void GetRecord()
    {
        record = Mathf.Max(record, ScoreKeeper.score);
        UpdateBestText();
    }

    private static void UpdateBestText()
    {
        recordText.text = String.Format("Record: {0}", record);
    }
}
