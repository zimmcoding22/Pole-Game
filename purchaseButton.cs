using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purchaseButton : MonoBehaviour
{
    public enum PurchaseType {removeAds, moonSetting};
    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        Debug.Log("in purchase button");
        switch (purchaseType)
        {
            case PurchaseType.removeAds:
                Debug.Log("purchasing remove ads");
                IAPManager.instance.BuyRemoveAds();
                break;
            case PurchaseType.moonSetting:
                Debug.Log("purchasing moon setting");
                IAPManager.instance.BuyMoonSetting();
                break;
        }
    }
}
