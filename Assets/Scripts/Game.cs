using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject holderRotX;
    public GameObject holderRotY;
    public GameObject holderPos;
    public GameObject model;

    private Quaternion startRotX;
    private Quaternion startRotY;
    private Vector3 startPos;

    public bool isGameOn;
    public bool isRotX;
    public bool isRotY;
    public bool isPos;

    // Use this for initialization
    void Start () {
        startRotX = holderRotX.transform.rotation;
        startRotY = holderRotY.transform.rotation;
        startPos = holderPos.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
        gameRotX();
	}

    private void gameRotX() {
        if (isGameOn == false)
            return;
        else {
           // holderRot.transform.rotation = Quaternion.eulerAngles = new Vector3(0, 30, 0);
        }
    }

    public void setIsGame(bool bb) {
        isGameOn = bb;
    }
}
