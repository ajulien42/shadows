using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStartScoreUIgame : MonoBehaviour {

	public	Button restart;
	public	Text score;
	private	float scoreFloat;
	public	Text hint;

	public	GameObject succes;
	public	GameObject defeat;
	public	GameObject showHideButton;
	public	GameObject inGameUI;

	public	Game[] lvl;
    public Game[] lvldouble;
    public	SettingAndMenu set;
    private bool doublemodel;

	private	bool running;
	private	int lvlrunning;
    private int doublerunning;
	// Use this for initialization
	//	void Start () {
	//
	//	}

	// Update is called once per frame
	void Update () {
		runLvl ();
	}
    //to do double

    public void setDoubleLvl(int i) {
        doublemodel = true;
        doublerunning = i - 3;
        lvldouble[doublerunning].isGameOn = true;
        setLvl(i);
    }

    public void setLvl(int i) {
		if (running == false) {
			scoreFloat = 100f;
			inGameUI.SetActive (true);
			showHideButton.SetActive (false);
			lvlrunning = i;
			lvl[i].isGameOn = true;
			hint.text = lvl[i].hint;
			running = true;
		}
	}

	public void runLvl() {
        if (running == false)
            return;
        else
        {
            if (lvl[lvlrunning].isGameOn == false && lvldouble[doublerunning].isGameOn == false)
            {
                endLvl();
                return;
            }

            scoreFloat -= Time.deltaTime;
            if (scoreFloat < 0) {
                scoreFloat = 0f;
                endLvl();
                return;
            }
            score.text = Mathf.Round(scoreFloat).ToString();
        }
	}

	public void endLvl() {
		running = false;
        doublemodel = false;
		set.SetLvlScore(lvlrunning, (int)Mathf.Round(scoreFloat));
		showHideButton.SetActive (true);
		defeat.SetActive (false);
		succes.SetActive (false);
		if (scoreFloat > 0)
			succes.SetActive (true);
		else
			defeat.SetActive (true);
	}

    public void restartLvl() {
        if (running == false)
        {
            if (lvlrunning == 3) {
                lvl[lvlrunning].initRandom();
                lvldouble[doublerunning].initRandom();
                setDoubleLvl(3);
            }
            lvl[lvlrunning].initRandom();
            setLvl(lvlrunning);
        }
    }
}
