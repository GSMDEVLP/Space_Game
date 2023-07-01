using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1f;
    [SerializeField] private RectTransform[] backgrounds;

    private Vector3 _startPos = new Vector3(1942, 0, 0);


    private void Update()
    {
        foreach (RectTransform bg in backgrounds)
        {
            bg.anchoredPosition += new Vector2(-scrollSpeed * Time.deltaTime, 0);

            if(bg.anchoredPosition.x < -bg.rect.width)
            {
                bg.anchoredPosition = _startPos;
            }

        }
    }
    
}
