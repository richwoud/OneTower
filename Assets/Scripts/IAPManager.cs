using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener //для получения сообщений из Unity Purchasing
{
    [SerializeField] private GameObject btnNoAds;
  

    IStoreController m_StoreController;

    private string noads = "com.richwoud.onetower.noads";
    private string moneypack400 = "com.richwoud.onetower.moneypack400";
    private string moneypack2400 = "com.richwoud.onetower.moneypack2400";
    private string moneypack4200 = "com.richwoud.onetower.moneypack4200";
    private string moneypack10000 = "com.richwoud.onetower.moneypack10000";
    private string moneypack25000 = "com.richwoud.onetower.moneypack25000";


    void Start()
    {
        InitializePurchasing();

        //if (PlayerPrefs.HasKey("firstStart") == false)
        //{
        //    PlayerPrefs.SetInt("firstStart", 1);
        //    RestoreMyProduct();
        //}

        RestoreVariable();
    }

    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(noads, ProductType.NonConsumable);
        builder.AddProduct(moneypack400, ProductType.Consumable);
        builder.AddProduct(moneypack2400, ProductType.Consumable);
        builder.AddProduct(moneypack4200, ProductType.Consumable);
        builder.AddProduct(moneypack10000, ProductType.Consumable);
        builder.AddProduct(moneypack25000, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    void RestoreVariable()
    {
        if (PlayerPrefs.HasKey("ads"))
        {
            btnNoAds.SetActive(false);
        }

    }

    public void BuyProduct(string productName)
    {
        m_StoreController.InitiatePurchase(productName);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        var product = args.purchasedProduct;

        if (product.definition.id == noads)
        {
            Product_NoAds();
        }

        if (product.definition.id == moneypack400)
        {
            Product_Moneypack400();
        }

        if (product.definition.id == moneypack2400)
        {
            Product_Moneypack2400();
        }
        if (product.definition.id == moneypack4200)
        {
            Product_Moneypack4200();
        }
        if (product.definition.id == moneypack10000)
        {
            Product_Moneypack10000();
        }
        if (product.definition.id == moneypack25000)
        {
            Product_Moneypack25000();
        }
        Debug.Log($"Purchase Complete - Product: {product.definition.id}");

        return PurchaseProcessingResult.Complete;
    }

    private void Product_NoAds()
    {
        PlayerPrefs.SetInt("ads", 0);
        btnNoAds.SetActive(false);
    }
    private void Product_Moneypack400()
    {
        _DonateShop.instance.On_BtnLot1();
    }
    private void Product_Moneypack2400()
    {
        _DonateShop.instance.On_BtnLot2();

    }
    private void Product_Moneypack4200()
    {
        _DonateShop.instance.On_BtnLot3();

    }
    private void Product_Moneypack10000()
    {
        _DonateShop.instance.On_BtnLot4();

    }
    private void Product_Moneypack25000()
    {
        _DonateShop.instance.On_BtnLot5();

    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"In-App Purchasing initialize failed: {error}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }


    //public void RestoreMyProduct()
    //{
    //    if (CodelessIAPStoreListener.Instance.StoreController.products.WithID(noads).hasReceipt)
    //    {
    //        Product_NoAds();
    //    }

    //    if (CodelessIAPStoreListener.Instance.StoreController.products.WithID(vip).hasReceipt)
    //    {
    //        Product_VIP();
    //    }
    //}
}
