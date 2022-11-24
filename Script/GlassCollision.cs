using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GlassCollision : MonoBehaviour
{
    private int waterCount = 0;
    [SerializeField] private int totalPartical = 1000;
    public int currentPartical;
    //private float colaYuzdesi = 0;
    public GameObject[] icecekParticals;
    [SerializeField] private GameObject[] waterParticals;
    //public GameObject fantaPartical;
    //public GameObject particalManager;
    [SerializeField] private TextMeshProUGUI yuzdelikText;
    [SerializeField] private GameObject bardakDoluluk;
    [SerializeField] private GameObject costumer;
    private float choosenBeveragePercent;
    private int choosenBeverageCount = 0;
    public static GlassCollision instance;
    [SerializeField] private TextMeshProUGUI cashText;
    public GameObject siparisVermeBlok;
    [SerializeField] private GameObject[] beverageButtons;
    private bool isFullGlass = false;

    private void Awake()
    {
        instance = this;
        currentPartical = totalPartical;
        yuzdelikText.text = "100/" + choosenBeveragePercent.ToString("0");
        StartCoroutine(BardakRenkDoluluk(30, 10, 5, 230, 230, 230));
        bardakDoluluk.transform.localScale = new Vector3(1.1f, (float)(totalPartical - currentPartical) / totalPartical, 1.1f);
        bardakDoluluk.transform.localPosition = new Vector3(0f, bardakDoluluk.transform.localScale.y - 1, 0f);
        gameObject.GetComponent<DragAndDrop>().enabled = false;
    }

    void OnParticleCollision(GameObject test)
    {
        if(!isFullGlass)
        {
            if (currentPartical >= 0)
            {
                if (test.CompareTag(Custemer.instance.choosenBeverage))
                {
                    choosenBeverageCount++;
                    currentPartical--;
                    Debug.Log("i?ecek -> " + choosenBeverageCount);
                }
                else
                {
                    waterCount++;
                    currentPartical--;
                    Debug.Log("su -> " + waterCount);
                }
                CalculatePercent();
                bardakDoluluk.transform.localScale = new Vector3(1.1f, ((float)(totalPartical - currentPartical) / totalPartical) * 3 / 4, 1.1f);
                bardakDoluluk.transform.localPosition = new Vector3(0f, bardakDoluluk.transform.localScale.y - 1, 0f);
            }
            else
            {
                isFullGlass = true;
                Debug.Log("Bardak Doldu");
                //gameObject.GetComponent<SwipeObject>().enabled = false;
                siparisVermeBlok.SetActive(true);
                gameObject.GetComponent<DragAndDrop>().enabled = true;
            }
        }
        
    }

    private void CalculatePercent()
    {
        choosenBeveragePercent = ((float)choosenBeverageCount / (choosenBeverageCount + waterCount)) * 100;
        yuzdelikText.text = "100/" + choosenBeveragePercent.ToString("0");
    }

    public void True(GameObject test)
    {
        test.SetActive(true);
    }
    public void False(GameObject test)
    {
        test.SetActive(false);
    }

    IEnumerator BardakRenkDoluluk(float r, float g, float b, float rMax, float gMax, float bMax)
    {
        float rMin = r;
        float gMin = g;
        float bMin = b;
        while (true)
        {
            r = rMax - ((rMax - rMin) * (choosenBeveragePercent / 100));
            b = bMax - ((bMax - bMin) * (choosenBeveragePercent / 100));
            g = gMax - ((gMax - gMin) * (choosenBeveragePercent / 100));
            Renderer renderer = bardakDoluluk.GetComponent<Renderer>();
            renderer.material.color = new Color(r / 255, g / 255, b / 255);
            yield return null;
        }


    }
    public void buttonActive()
    {
        for (int i = 0; i < beverageButtons.Length; i++)
        {
            True(beverageButtons[i]);
        }
    }
    public void FinishGame()
    {
        for(int i = 0; i < beverageButtons.Length; i++)
        {
            False(beverageButtons[i]);
            False(icecekParticals[i]);
            False(waterParticals[i]);
        }
        False(costumer);
        //False(particalManager);
        True(costumer);
        waterCount = 0;
        choosenBeverageCount = 0;
        currentPartical = totalPartical;
        bardakDoluluk.transform.localScale = new Vector3(1.1f, (float)(totalPartical - currentPartical) / totalPartical, 1.1f);
        bardakDoluluk.transform.localPosition = new Vector3(0f, bardakDoluluk.transform.localScale.y - 1, 0f);
        yuzdelikText.text = "100/" + choosenBeveragePercent.ToString("0");
        isFullGlass = false;
    }

    public void MoneyEarn()
    {
        if (Custemer.instance.choosenPercent <= choosenBeveragePercent)
        {
            CashManager.instance.totalCash += Random.Range(100, 150);
            cashText.text = CashManager.instance.totalCash.ToString();
            Debug.Log("Kazand?n");
        }
        else
        {
            Debug.Log("Kaybettin");
        }
    }

}
