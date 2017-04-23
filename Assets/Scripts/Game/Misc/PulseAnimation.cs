using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PulseAnimation : MonoBehaviour
{
    public AnimationCurve AnimationCurve;

    public float AnimationSpeed = 1;
    public float MinAlpha = 0;
    public float MaxAlpha = 1;

    private float _timePassed;
    private SpriteRenderer _renderer;

    private Coroutine _animationRoutine;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void PlayAnimation()
    {
        if (_animationRoutine != null)
            StopAnimation();

        _animationRoutine = StartCoroutine(PulseRoutine());
    }

    public void StopAnimation()
    {
        //_timePassed = 0;
        StopCoroutine(_animationRoutine);
    }

    private IEnumerator PulseRoutine()
    {
        while (true)
        {
            float curvePos = AnimationCurve.Evaluate(_timePassed);
            float currentAlpha = Mathf.Lerp(MinAlpha, MaxAlpha, curvePos);
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, currentAlpha);

            _timePassed += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
}
