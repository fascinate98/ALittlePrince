using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateImage : MonoBehaviour
{
    private bool IsTouch = false;
    private Vector3 clickPos;
  

    public GameObject m_handleSprite;

    // Start is called before the first frame update
    void Start()
    {
        if(m_handleSprite == null)
        {
            m_handleSprite = GetComponent<GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPos = Input.mousePosition;
            Debug.Log("마우스 찍" + clickPos.x + "," + clickPos.y);
        }

        //drag = clickPosX - mousePos.x;

        ////Quaternion quaternion = transform.localRotation;
        ////quaternion.z += drag;
        ////transform.localRotation = quaternion;
    }

    private void OnMouseDrag()
    {

        Vector3 Center =  Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        //Debug.Log(Center.x + "," + Center.y);

        float Angle1 = GetAngle(Center, mousePosition);  // 센터랑 마우스 현재위치 각도
        float Angle2 = GetAngle(Center, clickPos);   //센터랑 마우스 처음위치 각도

        float Angle3 = Angle2 - Angle1;  //뺌

        transform.rotation = Quaternion.Euler(0, 0, Angle3);  //회전

        Debug.Log(Angle1 + " , " + Angle2);
    }

    public static float GetAngle(Vector3 vStart, Vector3 vEnd) //-180~180
    {
        Vector3 v = vEnd - vStart;
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;   //각도를 구해쥼
    }

    public static float CalculateAngle(Vector3 from, Vector3 to) //0~360
    {
        return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
    }
}