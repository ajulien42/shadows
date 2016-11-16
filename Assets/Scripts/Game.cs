using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{

    public GameObject holderRotX;
    public GameObject temoinX;
    public GameObject holderRotY;
    public GameObject holderPos;
    public GameObject wall;
    public string hint;

    private Quaternion startRotX;
    private Quaternion startRotY;
    private Vector3 startPos;
    private Renderer rend;
    private Renderer rendModel;
    private Color color;
    private float diffAnglesX;
    private float diffAnglesY;

    public bool isGameOn;
    public bool isRotX;
    public bool isRotY;
    public bool isPos;
    public bool reversePos;

    // Use this for initialization
    void Start()
    {
        startRotX = holderRotX.transform.rotation;
        startRotY = holderRotY.transform.rotation;
        startPos = holderPos.transform.position;

        rend = wall.GetComponent<Renderer>();
        rendModel = this.GetComponent<Renderer>();

        diffAnglesX = 0f;
        diffAnglesY = 0f;
        initRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOn)
            gameCheck();
    }

    private void gameCheck()
    {
        float colorx = 0;
        float colory = 0;
        float colorPos = 1;

        if (isRotX)
        {
            diffAnglesX = Quaternion.Angle(startRotX, temoinX.transform.rotation);
            colorx = (180 - diffAnglesX) / 180; 
            
        }
        if (isRotY) {
            diffAnglesY = Quaternion.Angle(startRotY, holderRotY.transform.rotation);
            colory = (180 - diffAnglesY) / 180;
        }
        if (isPos) {
            colorPos = 1 - Vector3.Distance(startPos, holderPos.transform.position);
            foreach (Material mat in rendModel.materials)
                mat.SetColor("_SpecColor", new Color(colorPos, 0, 0));
        }
        color = new Color(0, colory, colorx);
        rend.material.SetColor("_SpecColor", color);
        
        
        if (diffAnglesX < 6f && diffAnglesY < 6f && Input.GetMouseButton(0) == false && colorPos > 0.9)
            isGameOn = false;
    }

    void OnMouseDrag()
    {
        if (isGameOn == true)
        {
            float rotSpeed = 300;
            float movSpeed = 4;
            if (isRotX == true && Input.GetKey("left ctrl"))
            {
                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;

                holderRotX.transform.rotation *= Quaternion.Euler(0, 0, -rotX);
                temoinX.transform.rotation *= Quaternion.Euler(0, 0, -rotX);
            }
            
            else if (isRotY == true && Input.GetKey("left shift"))
            {
                float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

                holderRotY.transform.rotation *= Quaternion.Euler(-rotY, 0, 0);
            }
            else if (isPos == true)
            {
                float posX = Input.GetAxis("Mouse X") * movSpeed * Mathf.Deg2Rad;
                float posY = Input.GetAxis("Mouse Y") * movSpeed * Mathf.Deg2Rad;

                if (reversePos)
                {
                    holderPos.transform.Translate(holderPos.transform.up * -posX);
                    holderPos.transform.Translate(holderPos.transform.right * posY);
                }
                else
                {
                    holderPos.transform.Translate(holderPos.transform.up * posX);
                    holderPos.transform.Translate(holderPos.transform.right * -posY);
                }
            }
        }
    }

    public void initRandom() {
        if (isRotX) {
            float x = Random.Range(90, 250);
            holderRotX.transform.rotation *= Quaternion.Euler(0, 0, x);
            temoinX.transform.rotation *= Quaternion.Euler(0, 0, x);
        }
        if (isRotY)
            holderRotY.transform.rotation *= Quaternion.Euler(Random.Range(90, 250), 0, 0);
        if (isPos) {
            
            holderPos.transform.Translate(holderPos.transform.up * Random.Range(-1.1f,1.1f));
            holderPos.transform.Translate(holderPos.transform.right * Random.Range(-0.7f, 0.7f));
        }
    }

}
