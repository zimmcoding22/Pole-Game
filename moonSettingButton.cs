using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonSettingButton : MonoBehaviour
{
    public GameObject moonSetting;
    public GameObject moonLevelText;

    void Update()
    {
        if (PlayerPrefs.GetInt("moon_setting_bought") == 1 && moonSetting.activeSelf)
        {
            moonSetting.SetActive(false);
            moonLevelText.SetActive(false);
        }
    }
}
