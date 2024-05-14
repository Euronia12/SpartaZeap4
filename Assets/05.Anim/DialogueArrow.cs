using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueArrow : MonoBehaviour
{
    private float fadeTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveArrow());
    }

    IEnumerator MoveArrow()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(Vector3.down * 0.2f));
            yield return StartCoroutine(Fade(Vector3.up * 0.2f));
        }
    }

    private IEnumerator Fade(Vector3 direction)
    {
        float current = 0;
        float percent = 0;
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;
            transform.position = Vector2.Lerp(transform.position, transform.position + direction, percent);
            yield return null;
        }
    }
}
