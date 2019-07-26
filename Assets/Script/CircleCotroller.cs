using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandleColor
{
    Pink = 0,
    Blue = 1,
    Green = 2
}

[System.Serializable]
public class CircleColor
{
    public HandleColor handle { get; set; }
    public float minAngle { get; set; }
    public float maxAngle { get; set; }

    public CircleColor()
    {

    }

    public CircleColor(HandleColor handleColor, float min, float max)
    {
        handle = handleColor;
        minAngle = min;
        maxAngle = max;
    }

     //앵글이 민보다 크고 맥스보단 작고! 작거나 같다로 ㄱㄱ 그건상간업서 


    public bool IsInRange(float Angle)
    {
        //이렇게하면
        //0.00001 ~ 90 = 핑크
        //90.00001 ~ 180 = ..... 그래서 같다를 하나는 빼준거야!!
        //270.0001 ~ 360 = ?ㅅ? 이해했찌? dmd..응  마지막
        if (minAngle < Angle && maxAngle >= Angle)
            return true;
        else
            return false;
    }
}


public class CircleCotroller : MonoBehaviour
{
    private bool IsTouch = false;
    private Vector3 clickPos;
    public GameObject m_handleSprite;
    public HandleColor color;


    public List<CircleColor> ColorList = new List<CircleColor>();
   
    // Start is called before the first frame update

    void InitstallizeColorList(int colorCount)
    {
        float unit = 360 / colorCount;  //360 /4 = 90 
        for(int i = 0; i < colorCount; i++)
        { 
            CircleColor circleColor = new CircleColor(); 
            circleColor.minAngle = unit * i;  // 90 * 0 = 0
            circleColor.maxAngle = unit * (i+1); // 90 * 1 = 90
            circleColor.handle = (HandleColor)i; // i = 0 , HandleColor 0 is Pink.

            Debug.Log(i + 1 + " 번째 minAngle :" + circleColor.minAngle);
            Debug.Log(i + 1 + " 번째 maxAngle :" + circleColor.maxAngle);
            Debug.Log(i + 1 + " 번째 color :" + circleColor.handle); 

            ColorList.Add(circleColor);
        }
    }
    void Start()
    {
        InitstallizeColorList(3); 
        if (m_handleSprite == null)
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
        }
    }

    private void OnMouseDrag()
    {
        Vector3 Center =  Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        float Angle1 = CalculateAngle(Center, mousePosition);  // 센터랑 마우스 현재위치 각도
        float Angle2 = CalculateAngle(Center, clickPos);   //센터랑 마우스 처음위치 각도

        float Angle3 = Angle1 - Angle2;  //뺌

        transform.rotation = Quaternion.Euler(0, 0, Angle3);  //회전

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