using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingAndMenu : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject LvlSelectUi;
    public Button soundButton;
	public Button[] pinLvl;
    // SETTING
    // Use this for initialization
    void Start() {
        LvlSelectUi.SetActive(false);
		pinLvl [0].interactable = false;
		pinLvl [1].interactable = false;
		pinLvl [2].interactable = false;
		pinLvl [3].interactable = false;
        if (PlayerPrefs.GetString("firstGame", "nop") != null)
            RegularInit();
    }

    // Update is called once per frame
    public void RegularInit() {
        PlayerPrefs.SetString("firstGame", "nop");
        PlayerPrefs.SetInt("lvl0Access", 1);
        PlayerPrefs.SetInt("lvl1Access", 0);
        PlayerPrefs.SetInt("lvl2Access", 0);
        PlayerPrefs.SetInt("lvl3Access", 0);
        PlayerPrefs.Save();
		pinLvl [0].interactable = true;
    }

    public void AdminInit() {
        PlayerPrefs.SetString("firstGame", null);
        PlayerPrefs.SetInt("lvl0Access", 1);
        PlayerPrefs.SetInt("lvl1Access", 1);
        PlayerPrefs.SetInt("lvl2Access", 1);
        PlayerPrefs.SetInt("lvl3Access", 1);
		pinLvl [0].interactable = true;
		pinLvl [1].interactable = true;
		pinLvl [2].interactable = true;
		pinLvl [3].interactable = true;
        PlayerPrefs.Save();
    }

    public void SetLvlAcces(int num, int ok) {
        PlayerPrefs.SetInt("lvl" + num.ToString() + "Acces", ok);
        PlayerPrefs.Save();
		pinLvl [num].interactable = true;

    }

    //MENU

    public void RegularGameButton() {
        MainMenu.SetActive(false);
		LvlSelectUi.SetActive (true);
    }

    public void TestGameButton()
    {
        MainMenu.SetActive(false);
        AdminInit();
		LvlSelectUi.SetActive (true);
    }

    public void ResetSave() {
        RegularInit();
    }

    //todo

    public void sound() { 
		ColorBlock cb = soundButton.colors;
		Debug.Log (soundButton.colors.highlightedColor);
		if (soundButton.colors.highlightedColor == Color.red){
//			Debug.Log (" toto");
			cb.highlightedColor = Color.green;
			soundButton.colors= cb;
		}
		else if (soundButton.colors.highlightedColor == Color.green){
//			Debug.Log (" caca");
			cb.highlightedColor = Color.red;
			soundButton.colors= cb;
		}
        //Debug.Log(soundButton.colors.highlightedColor);
//        Debug.Log(Color.green);
    }

}
