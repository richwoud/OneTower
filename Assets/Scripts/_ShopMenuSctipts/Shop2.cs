using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shop2 : MonoBehaviour
{
    
    [Header("Магазин")]
    public List<Item> shopItems = new List<Item>();
    [Header("Текст на кнопках товаров")]
    public TextMeshProUGUI[] shopBtnText;
    [Header("Кнопки товаров")]
    public Button[] shopBttns;
    [Header("Панелька магазина")]
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
    public void BuyBttn(int index) //Метод при нажатии на кнопку покупки товара (индекс товара)
    {
        int cost = shopItems[index].cost; //Рассчитываем цену в зависимости от цены товара
     
        if (gUIUpdateScript.ordinaryMoney >= shopItems[index].cost) // Иначе, если товар нажатой кнопки - это не бонус, и денег >= цена
        {
            gUIUpdateScript.ordinaryMoney -= cost; // Вычитаем цену из денег
            if (shopItems[index].needCostMultiplier) shopItems[index].cost *= shopItems[index].costMultiplier; // Если товару нужно умножить цену, то умножаем на множитель
            shopItems[index].levelOfItem++; // Поднимаем уровень предмета на 1
        }
        else 
        updateCosts(); //Обновить текст с ценами
    }
    private void updateCosts() // Метод для обновления текста с ценами
    {
        for (int i = 0; i < shopItems.Count; i++) // Цикл выполняется, пока переменная i < кол-ва товаров
        { 
            shopBtnText[i].text = "Buy \n" + "$" + shopItems[i].cost; //обновляем текст кнопки с обычной ценой
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
    public class Item // Класс товара
    {
        [Tooltip("Цена товара")]
        public int cost;
        public int levelOfItem; // Уровень товара
        [Space]
        [Tooltip("Нужен ли множитель для цены?")]
        public bool needCostMultiplier;
        [Tooltip("Множитель для цены")]
        public int costMultiplier;
    }
    [Serializable]
    public class Save
    {
        public int[] levelOfItem;
    }
}
