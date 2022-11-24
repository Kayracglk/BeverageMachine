using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Custemer : MonoBehaviour
{
    public int choosenPercent;
    public static Custemer instance;
    public List<string> beverageList = new List<string>();
    [SerializeField] GameObject[] modelList;
    private int modelCount = 0;
    public string choosenBeverage;
    [SerializeField] private TextMeshProUGUI yuzdelikText;

    private void Awake()
    {
        instance = this;
        beverageList.Add("Cola");
    }

    void OnEnable()
    {
        choosenPercent = Random.Range(20, 90);
        choosenBeverage = beverageList[Random.Range(0, beverageList.Count)];
        yuzdelikText.text = choosenBeverage + " -> " + choosenPercent.ToString();
        modelList[modelCount].SetActive(false);
        modelCount++;
        if (modelCount == modelList.Length) modelCount = 0;
        modelList[modelCount].SetActive(true);
        //MakeTrue();

    }

    /*private void MakeTrue()
    {
        if (!GlassCollision.instance) return;
        GlassCollision.instance.True(GlassCollision.instance.colaPartical);
        GlassCollision.instance.True(GlassCollision.instance.waterPartical);
        //GlassCollision.instance.True(GlassCollision.instance.particalManager);
    }*/
}
