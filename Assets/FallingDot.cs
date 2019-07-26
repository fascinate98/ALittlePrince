using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Handle")
        {
            for(int i = 0; i < GameManager.Instance.circleController.ColorList.Count; i++)
            {
                GameManager.Instance.circleController.ColorList[i].IsInRange(270);     //여기에 떠러지는 각도를 너으면 대 
            }
        }
    }
}
