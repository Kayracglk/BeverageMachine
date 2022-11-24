using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnClickButton : MonoBehaviour
{
    [SerializeField] private ParticleSystem beveragePartical;
    [SerializeField] private ParticleSystem waterPartical;
    private bool isClicked = false;

    private void OnMouseDown()
    {
        if (isClicked)
        {
            waterPartical.Stop();
            beveragePartical.Stop();
            isClicked = false;
        }
        else
        {
            isClicked = true;
            StartCoroutine(enumerator());
        }

    }

    private void OnEnable()
    {
        beveragePartical.gameObject.SetActive(true);
        waterPartical.gameObject.SetActive(true);
        waterPartical.Stop();
        beveragePartical.Stop();
    }


    private IEnumerator enumerator()
    {
        if(isClicked)
        {
            yield return new WaitForSeconds(1f);
            beveragePartical.Stop();
            waterPartical.Play();
            StartCoroutine(enumerator1());
        }
        else
        {
            waterPartical.Stop();
            beveragePartical.Stop();
        }
    }

    private IEnumerator enumerator1()
    {
        if(isClicked)
        {
            yield return new WaitForSeconds(1f);
            waterPartical.Stop();
            beveragePartical.Play();
            StartCoroutine(enumerator());
        }
        else
        {
            waterPartical.Stop();
            beveragePartical.Stop();
        }
    }
}
