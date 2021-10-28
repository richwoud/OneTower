using System;
using UnityEngine;
using UnityEngine.Purchasing; //библиотека с покупками, будет доступна когда активируем сервисы

public class IAPCore : MonoBehaviour, IStoreListener //дл€ получени€ сообщений из Unity Purchasing
{
    [SerializeField] private GameObject panelAds;
   

    private static IStoreController m_StoreController;          //доступ к системе Unity Purchasing
    private static IExtensionProvider m_StoreExtensionProvider; // подсистемы закупок дл€ конкретных магазинов

    public static string noads = "noads"; //одноразовые - nonconsumable
    public static string ItemLot1 = "ItemLot1"; //многоразовые - consumable
    public static string ItemLot2 = "ItemLot2"; //многоразовые - consumable
    public static string ItemLot3 = "ItemLot3"; //многоразовые - consumable
    public static string ItemLot4 = "ItemLot4"; //многоразовые - consumable
    public static string ItemLot5 = "ItemLot5"; //многоразовые - consumable


    void Start()
    {
        if (m_StoreController == null) //если еще не инициализаровали систему Unity Purchasing, тогда инициализируем
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized()) //если уже подключены к системе - выходим из функции
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //ѕрописываем свои товары дл€ добавлени€ в билдер
        builder.AddProduct(noads, ProductType.NonConsumable);
        builder.AddProduct(ItemLot1, ProductType.Consumable);
        builder.AddProduct(ItemLot2, ProductType.Consumable);
        builder.AddProduct(ItemLot3, ProductType.Consumable);
        builder.AddProduct(ItemLot4, ProductType.Consumable);
        builder.AddProduct(ItemLot5, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void Buy_noads()
    {
        BuyProductID(noads);
    }

    public void Buy_ItemLot1()
    {
        BuyProductID(ItemLot1);
    }
    public void Buy_ItemLot2()
    {
        BuyProductID(ItemLot2);
    }
    public void Buy_ItemLot3()
    {
        BuyProductID(ItemLot3);
    }
    public void Buy_ItemLot4()
    {
        BuyProductID(ItemLot4);
    }
    public void Buy_ItemLot5()
    {
        BuyProductID(ItemLot5);
    }


    void BuyProductID(string productId)
    {
        if (IsInitialized()) //если покупка инициализирована 
        {
            Product product = m_StoreController.products.WithID(productId); //находим продукт покупки 

            if (product != null && product.availableToPurchase) //если продукт найдет и готов дл€ продажи
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product); //покупаем
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) //контроль покупок
    {
        if (String.Equals(args.purchasedProduct.definition.id, noads, StringComparison.Ordinal)) //тут замен€ем наш ID
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            //действи€ при покупке
            if (PlayerPrefs.HasKey("ads") == false)
            {
                PlayerPrefs.SetInt("ads", 0);
                panelAds.SetActive(false);
               
            }

        }
        else if (String.Equals(args.purchasedProduct.definition.id, ItemLot1, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            _DonateShop.instance.On_BtnLot1();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, ItemLot2, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            //действи€ при покупке
            _DonateShop.instance.On_BtnLot2();

        }
        else if (String.Equals(args.purchasedProduct.definition.id, ItemLot3, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            //действи€ при покупке
            _DonateShop.instance.On_BtnLot3();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, ItemLot4, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            //действи€ при покупке
            _DonateShop.instance.On_BtnLot4();

        }
        else if (String.Equals(args.purchasedProduct.definition.id, ItemLot5, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            //действи€ при покупке
            _DonateShop.instance.On_BtnLot5();
        }

        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }

    public void RestorePurchases() //¬осстановление покупок (только дл€ Apple). ” гугл это автоматический процесс.
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer) //если запущенно на эпл устройстве
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) =>
            {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("ads") == true)
        {
            panelAds.SetActive(false);
        }
        else
        {
            panelAds.SetActive(true);  
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }



}
