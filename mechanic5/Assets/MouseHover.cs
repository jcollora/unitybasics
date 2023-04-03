using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseHover : MonoBehaviour
{
    GameObject canvas;

    private Vector3 originalPosition;
    public float bounceHeight = 0.2f;
    public float bounceSpeed = 10f;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        originalPosition = transform.position;
    }

    private void OnMouseEnter()
    {
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (canvas.transform.GetChild(i).tag == tag)
            {
                canvas.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        // start the bouncing animation
        StartCoroutine(BounceAnimation());
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        // reset the object's position
        transform.position = originalPosition;
        StopAllCoroutines();
    }

    IEnumerator BounceAnimation()
    {
        while (true)
        {
            float newY = originalPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }
    }
}