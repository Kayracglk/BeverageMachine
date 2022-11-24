using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeObject : MonoBehaviour
{

    //private Vector2 startTouchPosition, endTouchPosition;
    private Touch touch;
    private float speed = 0.2f;
    [SerializeField] float xLimitLeft = -4f, xLimitRight = 4.5f;
    float limitedZ;

    void Start()
    {

    }


    void Update()
    {
        Swipe();
    }

    void Swipe()
    {
        limitedZ = transform.position.z + touch.deltaPosition.x * Time.deltaTime * speed;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(limitedZ, xLimitLeft, xLimitRight));
            }
        }
    }
}
