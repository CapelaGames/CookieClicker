using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class cube : MonoBehaviour
{
    public Color color;

}

public class CookieManager : MonoBehaviour
{
    [SerializeField] private int cookies = 0;
    [SerializeField] private int cookiesPerClick = 1;
    [SerializeField] private Text cookieText;
    [SerializeField] private Text upgradeText;

    //updates
    private int costToUpdate = 5;


    private void Start()
    {
        UpdateCookieText();
        UpdateUpgradeText();
    }

    public void AddCookie()
    {
        cookies += cookiesPerClick;

        UpdateCookieText();
    }

    public void UpgradeCookiesPerClick()
    {
        if (cookies >= costToUpdate)
        {
            cookies -= costToUpdate;
            cookiesPerClick++;
            costToUpdate = costToUpdate * 2;
            UpdateCookieText();
            UpdateUpgradeText();
        }
    }

    private void UpdateUpgradeText()
    {
        if(upgradeText != null)
        {
            upgradeText.text = "Upgrade " + costToUpdate;
        }
    }

    private void UpdateCookieText()
    {
        if (cookieText != null)
        {
            switch (cookies)
            {
                case 0:
                    cookieText.text = "No Cookies";
                    break;
                case 1:
                    cookieText.text = "One Cookie";
                    break;
                default:
                    cookieText.text = cookies + " Cookies";
                    break;
            }
        }
        else
        {
            Debug.LogWarning("cookie text not set");
        }
    }
}
