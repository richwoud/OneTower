using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shop2 : MonoBehaviour
{
    
    [Header("�������")]
    public List<Item> shopItems = new List<Item>();
    [Header("����� �� ������� �������")]
    public TextMeshProUGUI[] shopBtnText;
    [Header("������ �������")]
    public Button[] shopBttns;
    [Header("�������� ��������")]
    public GameObject shopPan;
    GUIUpdateScript gUIUpdateScript;
    private Save save = new Save();

    private void Awake()
    {

        if (PlayerPrefs.HasKey("Save"))
        {

            save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));

            for (int i = 0; i < shopItems.Count; i++)
            {
                shopItems[i].levelOfItem = save.levelOfItem[i];

                if (shopItems[i].needCostMultiplier) shopItems[i].cost *= (int)Mathf.Pow(shopItems[i].costMultiplier, shopItems[i].levelOfItem);

            }
        }
    }
    private void Start()
    {
        gUIUpdateScript = GetComponent<GUIUpdateScript>();
        updateCosts();
    }
    public void BuyBttn(int index) //����� ��� ������� �� ������ ������� ������ (������ ������)
    {
        int cost = shopItems[index].cost; //������������ ���� � ����������� �� ���� ������
     
        if (gUIUpdateScript.ordinaryMoney >= shopItems[index].cost) // �����, ���� ����� ������� ������ - ��� �� �����, � ����� >= ����
        {
            gUIUpdateScript.ordinaryMoney -= cost; // �������� ���� �� �����
            if (shopItems[index].needCostMultiplier) shopItems[index].cost *= shopItems[index].costMultiplier; // ���� ������ ����� �������� ����, �� �������� �� ���������
            shopItems[index].levelOfItem++; // ��������� ������� �������� �� 1
        }
        else 
        updateCosts(); //�������� ����� � ������
    }
    private void updateCosts() // ����� ��� ���������� ������ � ������
    {
        for (int i = 0; i < shopItems.Count; i++) // ���� �����������, ���� ���������� i < ���-�� �������
        { 
            shopBtnText[i].text = "Buy \n" + "$" + shopItems[i].cost; //��������� ����� ������ � ������� �����
        }
    }
    private void Update()
    {
       
        save.levelOfItem = new int[shopItems.Count];
      
        for (int i = 0; i < shopItems.Count; i++)
        {
            save.levelOfItem[i] = shopItems[i].levelOfItem;
            
        }
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(save));
    }

    [Serializable]
    public class Item // ����� ������
    {
        [Tooltip("���� ������")]
        public int cost;
        public int levelOfItem; // ������� ������
        [Space]
        [Tooltip("����� �� ��������� ��� ����?")]
        public bool needCostMultiplier;
        [Tooltip("��������� ��� ����")]
        public int costMultiplier;
    }
    [Serializable]
    public class Save
    {
        public int[] levelOfItem;
    }
}
