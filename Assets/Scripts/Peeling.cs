using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeling : MonoBehaviour
{
    [SerializeField] private GameObject wax;

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;
    SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] int value = 30;
    [SerializeField] int plusValue;
    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY)
                    {
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if ((swipeValue > 0 || swipeValue < 0)) //up- down swipe
                        {
                            if (value <= 120)
                            {
                                Debug.Log("Up- Down swipe ");
                                AnimatorController._instance.IsStop();
                                skinnedMeshRenderer.SetBlendShapeWeight(1, value);
                                Debug.Log("Value= " + value);

                            }



                        }
                    }
                    value += plusValue;

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0 || swipeValue < 0) //right - left swipe 
                        {
                            Debug.Log("Right Left swipe");

                        }
                    }
                    break;
            }
        }
    }
}

