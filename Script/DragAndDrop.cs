using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }
    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()

    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = GetMouseAsWorldPoint()  - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection , out hitInfo))
        {
            if(hitInfo.transform.CompareTag("BardakBirakma") && GlassCollision.instance.currentPartical <= 0)
            {
                GlassCollision.instance.MoneyEarn();
                GlassCollision.instance.FinishGame();
                gameObject.transform.position = startPosition;
                GlassCollision.instance.siparisVermeBlok.SetActive(false);
                GlassCollision.instance.buttonActive();
                gameObject.GetComponent<DragAndDrop>().enabled = false;

            }
        }
    }
}
