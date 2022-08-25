using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class Coroutines
{
    public static IEnumerator WaitThen(float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }

    public static IEnumerator LerpColor(Graphic graphic, Color from, Color to, float duration, Action callback = null)
    {
        graphic.color = from;

        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;

            graphic.color = Color.Lerp(from, to, elapsed / duration);
        }
        
        graphic.color = to;
        callback?.Invoke();
    }
}