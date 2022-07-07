using UnityEngine;

public class restorePurchases : MonoBehaviour
{
    void Start()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer ||
            Application.platform != RuntimePlatform.OSXPlayer)
        {
            Debug.Log("isn't needed currently");
            //gameObject.SetActive(false);
        }
    }

    public void ClickRestorePurchaseButton()
    {
        IAPManager.instance.RestorePurchases();
    }
}
