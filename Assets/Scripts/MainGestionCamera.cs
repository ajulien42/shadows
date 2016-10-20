using UnityEngine;
using System.Collections;

public class MainGestionCamera : MonoBehaviour
{
    //machine à gaz droit devant
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;

    public GameObject Ui;

    private Vector3 MainPos;
    private Vector3 lvl1Pos;
    private Vector3 lvl2Pos;
    private Vector3 lvl3Pos;
    private Vector3 lvl4Pos;

    private Quaternion MainRot;
    private Quaternion lvl1Rot;
    private Quaternion lvl2Rot;
    private Quaternion lvl3Rot;
    private Quaternion lvl4Rot;

	public Game	lvl1Game;
	public Game	lvl2Game;
	public Game	lvl3Game;
	public Game	lvl4Game;

	public SettingAndMenu set;



    public int move; //initial cam is 42
    float t;

    // Use this for initialization
    void Start()
    {
        MainPos = Camera.main.transform.position;

        lvl1Pos = lvl1.transform.position;
        lvl2Pos = lvl2.transform.position;
        lvl3Pos = lvl3.transform.position;
        lvl4Pos = lvl4.transform.position;

        MainRot = Camera.main.transform.rotation;

        lvl1Rot = lvl1.transform.rotation;
        lvl2Rot = lvl2.transform.rotation;
        lvl3Rot = lvl3.transform.rotation;
        lvl4Rot = lvl4.transform.rotation;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam(this.move);
    }

    void MoveCam(int i)
    {
        if (i == 0)
            return;
        if (i == 1) {
            Ui.SetActive(false);
            mySlerp(lvl1Pos, lvl1Rot);
			lvl1Game.setIsGame(true);
        }
        if (i == 2) {
            Ui.SetActive(false);
            mySlerp(lvl2Pos, lvl2Rot);
        }
        if (i == 3) {
            Ui.SetActive(false);
            mySlerp(lvl3Pos, lvl3Rot);
        }
        if (i == 4) {
            Ui.SetActive(false);
            mySlerp(lvl4Pos, lvl4Rot);
        }
        if (i == 42) {
            Ui.SetActive(true);
			set.SetPin();
            mySlerp(MainPos, MainRot);
        }
    }
    private void mySlerp(Vector3 destV, Quaternion destR) {
        t += Time.deltaTime / 20;

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, destV, t);
        Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, destR, t);
		Debug.Log (t);
        if (t >= 0.17f)
        {
            this.move = 0;
            t = 0;
            Camera.main.transform.position = destV;
            Camera.main.transform.rotation = destR;
        }
    }

    public void setMoveTo(int i) {
        this.move = i;
    }
}