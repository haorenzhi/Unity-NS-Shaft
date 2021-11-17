using System;
using UnityEngine;
using UnityEngine.UI;

public class Termination : MonoBehaviour
{
    private static Text terminationText; // everyone has the same text

    // Use this for initialization
    internal void Start()
    {
        terminationText = GetComponent<Text>();
    }
    public static void showText()
    {
        terminationText.text = "<b>You died!</b>\n<size=50>Push \"ESC\" to play again!</size>";
    }

    public static void winText()
    {
        terminationText.text = "<b>Victory!</b>\n<size=50>Push \"ESC\" to play again!</size>";
    }
}
