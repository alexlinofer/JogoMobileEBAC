using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .3f;
    public float scaleBounce = 1.2f;
    public Ease ease = Ease.OutBounce;

    private Tweener _currentTweener;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) Bounce();
    }

    public void Bounce()
    {
        if(_currentTweener.IsActive())
        {
            transform.localScale = Vector3.one;
            _currentTweener.Kill();
        }

        _currentTweener = transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
