using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum Puzzles
{
    Combination,
    Combination_Code,
    Piano,
    Piano_Order,

}

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] Puzzles puzzle;

    [Header("Combination")]
    [SerializeField] TMP_Text digitLeft;
    [SerializeField] TMP_Text digitMiddle;
    [SerializeField] TMP_Text digitRight;
    [SerializeField] int digitLeftKey;
    [SerializeField] int digitMiddleKey;
    [SerializeField] int digitRightKey;
    [SerializeField] public GameObject pianoPanel;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void DigitLeft()
    {
        int digit1 = int.Parse(digitLeft.text);
        int digit2 = int.Parse(digitMiddle.text);
        int digit3 = int.Parse(digitRight.text);

        if (digit1 >= 9)
        {
            digit1 = 0;
            digitLeft.text = digit1.ToString();
        }
        else
        {
            digit1++;
            digitLeft.text = digit1.ToString();
        }

        CheckDigits();
    }

    public void DigitMiddle()
    {
        int digit1 = int.Parse(digitLeft.text);
        int digit2 = int.Parse(digitMiddle.text);
        int digit3 = int.Parse(digitRight.text);

        if (digit2 >= 9)
        {
            digit2 = 0;
            digitMiddle.text = digit2.ToString();
        }
        else
        {
            digit2++;
            digitMiddle.text = digit2.ToString();
        }

        CheckDigits();
    }

    public void DigitRight()
    {
        int digit1 = int.Parse(digitLeft.text);
        int digit2 = int.Parse(digitMiddle.text);
        int digit3 = int.Parse(digitRight.text);

        if (digit3 >= 9)
        {
            digit3 = 0;
            digitRight.text = digit3.ToString();
        }
        else
        {
            digit3++;
            digitRight.text = digit3.ToString();
        }

        CheckDigits();

    }

    public void CheckDigits()
    {
        int digit1 = int.Parse(digitLeft.text);
        int digit2 = int.Parse(digitMiddle.text);
        int digit3 = int.Parse(digitRight.text);

        if (digit1 == digitLeftKey && digit2 == digitMiddleKey && digit3 == digitRightKey)
        {
            digit1 = 0;
            digitLeft.text = digit1.ToString();
            digit2 = 0;
            digitMiddle.text = digit2.ToString();
            digit3 = 0;
            digitRight.text = digit3.ToString();
        }
    }

}
