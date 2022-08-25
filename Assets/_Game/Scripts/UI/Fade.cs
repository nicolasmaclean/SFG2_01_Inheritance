using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class Fade : MonoBehaviour
{
    [SerializeField]
    Color to = new Color(.4f, .4f, .4f, .65f);

    [SerializeField]
    float _in = .2f;

    [SerializeField]
    float _pause = 0;

    [SerializeField]
    float _out = .1f;

    Color from;
    Graphic graphic;

    void Awake()
    {
        graphic = GetComponent<Graphic>();
        from = graphic.color;
    }

    public void In()
    {
        StartCoroutine(Coroutines.LerpColor(graphic, from, to, _in));
    }

    public void InOut()
    {
        StartCoroutine(Animate());
        
        IEnumerator Animate()
        {
            yield return Coroutines.LerpColor(graphic, from, to, _in);
            yield return new WaitForSeconds(_pause);
            yield return Coroutines.LerpColor(graphic, to, from, _out);
        }
    }
}