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
        if (PlayerPrefs.GetString("firstGame") != "nop")
            RegularInit();
    }

    // Update is called once per frame
    public void RegularInit() {
        PlayerPrefs.SetString("firstGame", "nop");
        PlayerPrefs.SetInt("lvl0Access", 1);
        PlayerPrefs.SetInt("lvl1Access", 0);
        PlayerPrefs.SetInt("lvl2Access", 0);
        PlayerPrefs.SetInt("lvl3Access", 0);
		PlayerPrefs.SetInt("lvl0Score", -1);
		PlayerPrefs.SetInt("lvl1Score", -1);
		PlayerPrefs.SetInt("lvl2Score", -1);
		PlayerPrefs.SetInt("lvl3Score", -1);
        PlayerPrefs.Save();
		SetPin ();
    }

    public void AdminInit() {
        PlayerPrefs.SetString("firstGame", "nop");
        PlayerPrefs.SetInt("lvl0Access", 1);
        PlayerPrefs.SetInt("lvl1Access", 1);
        PlayerPrefs.SetInt("lvl2Access", 1);
        PlayerPrefs.SetInt("lvl3Access", 1);
		PlayerPrefs.SetInt("lvl0Score", -1);
		PlayerPrefs.SetInt("lvl1Score", -1);
		PlayerPrefs.SetInt("lvl2Score", -1);
		PlayerPrefs.SetInt("lvl3Score", -1);
        PlayerPrefs.Save();
		SetPin ();
    }
	// SetLvlAcces(0, 1) valid acces to lvl0
    private void SetLvlAcces(int num, int ok) {
        PlayerPrefs.SetInt("lvl" + num.ToString() + "Acces", ok);
        PlayerPrefs.Save();
    }
	// SetLvlScore(0, 25) set score of lvl to 25
	public void SetLvlScore(int lvl, int score){
		PlayerPrefs.SetInt ("lvl" + lvl.ToString () + "Score", score);
		PlayerPrefs.Save();
		if (score > 0)
			SetLvlAcces(lvl + 1, 1);
	}

	//CHECK Pin Lvl Every Time camera return to inGameUI "if" nightmare under this point
	public void SetPin(){
		pinLvl [0].interactable = false;
		pinLvl [1].interactable = false;
		pinLvl [2].interactable = false;
		pinLvl [3].interactable = false;
		Debug.Log (PlayerPrefs.GetInt("lvl2Score"));
		if (PlayerPrefs.GetInt ("lvl0Access") == 1) {
			pinLvl [0].interactable = true;
			ColorBlock cb = pinLvl[0].colors;
			if (PlayerPrefs.GetInt("lvl0Score") > 0)
				cb.normalColor = Color.green;
			if (PlayerPrefs.GetInt("lvl0Score") == 0)
				cb.normalColor = Color.red;
			else
				cb.normalColor = Color.white;
			pinLvl[0].colors = cb;
		}
		if (PlayerPrefs.GetInt ("lvl1Access") == 1) {
			pinLvl [1].interactable = true;
			ColorBlock cb = pinLvl[1].colors;
			if (PlayerPrefs.GetInt("lvl1Score") > 0)
				cb.normalColor = Color.green;
			else if (PlayerPrefs.GetInt("lvl1Score") == 0)
				cb.normalColor = Color.red;
			else
				cb.normalColor = Color.white;
			pinLvl[1].colors = cb;
		}
		if (PlayerPrefs.GetInt ("lvl2Access") == 1) {
			pinLvl [2].interactable = true;
			ColorBlock cb = pinLvl[2].colors;
			if (PlayerPrefs.GetInt("lvl2Score") > 0)
				cb.normalColor = Color.green;
			else if (PlayerPrefs.GetInt("lvl2Score") == 0)
				cb.normalColor = Color.red;
			else
				cb.normalColor = Color.white;
			pinLvl[2].colors = cb;
		}
		if (PlayerPrefs.GetInt ("lvl3Access") == 1) {
			pinLvl [3].interactable = true;
			ColorBlock cb = pinLvl[3].colors;
			if (PlayerPrefs.GetInt("lvl3Score") > 0)
				cb.normalColor = Color.green;
			else if (PlayerPrefs.GetInt("lvl3Score") == 0)
				cb.normalColor = Color.red;
			else
				cb.normalColor = Color.white;
			pinLvl[3].colors = cb;
		}
	}
	// end of nightmare

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

    //todo add music

    public void sound() { 
		ColorBlock cb = soundButton.colors;
		if (soundButton.colors.highlightedColor == Color.red){
			cb.highlightedColor = Color.green;
			soundButton.colors = cb;
		}
		else if (soundButton.colors.highlightedColor == Color.green){
			cb.highlightedColor = Color.red;
			soundButton.colors = cb;
		}
    }

}
