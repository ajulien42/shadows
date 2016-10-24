using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{

    public GameObject holderRotX;
    public GameObject holderRotY;
    public GameObject holderPos;
    public GameObject wall;
	public string hint;

    private Quaternion startRotX;
    private Quaternion startRotY;
    private Vector3 startPos;
    private Renderer rend;
    private Color color;
    private float diffAnglesX;
    private float diffAnglesY;

    public bool isGameOn;
    public bool isRotX;
    public bool isRotY;
    public bool isPos;

    // Use this for initialization
    void Start()
    {
        startRotX = holderRotX.transform.rotation;
        startRotY = holderRotY.transform.rotation;
        startPos = holderPos.transform.position;
        
        rend = wall.GetComponent<Renderer>();
        
		diffAnglesX = 0f;
		diffAnglesY = 0f;
        if (isRotX)
            holderRotX.transform.rotation *= Quaternion.Euler(0, 0, Random.Range(50, 310));

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOn)
            gameCheck();
    }

    private void gameCheck()
    {
        if (isRotX)
        {
            diffAnglesX = Quaternion.Angle(startRotX, holderRotX.transform.rotation);
            Debug.Log(diffAnglesX);
            color = new Color(0, 0, (180 - diffAnglesX) / 180);
            rend.material.SetColor("_SpecColor", color);
        }
		if (isRotY) {
		}
		if (isPos) {
		}
		if (diffAnglesX < 1f && diffAnglesY < 1f)
			isGameOn = false;
    }

    void OnMouseDrag()
    {
        if (isGameOn == true)
        {
            float rotSpeed = 180;
            if (isRotX == true)
            {
                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;

                holderRotX.transform.rotation *= Quaternion.Euler(0, 0, -rotX);
            }//transform.RotateAround(Vector3.right, rotY);
        }
    }
}
