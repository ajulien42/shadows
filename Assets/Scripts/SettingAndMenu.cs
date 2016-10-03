using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingAndMenu : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject LvlSelectUi;
    public Button soundButton;
    // SETTING
    // Use this for initialization
    void Start() {
        LvlSelectUi.SetActive(false);
        if (PlayerPrefs.GetString("firstGame", "nop") != null)
            RegularInit();
    }

    // Update is called once per frame
    public void RegularInit() {
        PlayerPrefs.SetString("firstGame", "nop");
        PlayerPrefs.SetInt("lvl1Access", 1);
        PlayerPrefs.SetInt("lvl2Access", 0);
        PlayerPrefs.SetInt("lvl3Access", 0);
        PlayerPrefs.SetInt("lvl4Access", 0);
        PlayerPrefs.Save();
    }

    public void AdminInit() {
        PlayerPrefs.SetString("firstGame", null);
        PlayerPrefs.SetInt("lvl1Access", 1);
        PlayerPrefs.SetInt("lvl2Access", 1);
        PlayerPrefs.SetInt("lvl3Access", 1);
        PlayerPrefs.SetInt("lvl4Access", 1);
        PlayerPrefs.Save();
    }

    public void SetLvlAcces(string num, int ok) {
        PlayerPrefs.SetInt("lvl" + num + "Acces", ok);
        PlayerPrefs.Save();
    }

    //MENU

    public void RegularGameButton() {
        MainMenu.SetActive(false);
    }

    public void TestGameButton()
    {
        MainMenu.SetActive(false);
        AdminInit();
    }

    public void ResetSave() {
        RegularInit();
    }

    //todo

    public void sound() {
        //if (soundButton.colors.normalColor != )
        //Debug.Log(soundButton.colors.highlightedColor);
        Debug.Log(Color.green);
    }

}
