using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    public int totalCash = 0;
    [SerializeField] private TextMeshProUGUI cashText;

    private void Awake()
    {
        cashText.text = totalCash.ToString();
        instance = this;
    }
}
