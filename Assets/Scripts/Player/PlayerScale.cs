using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .3f;
    public Ease ease = Ease.OutBounce;


    public void ScalePlayerOnStart()
    {
        StartCoroutine(ScaleFromZeroToOne());
    }


    IEnumerator ScaleFromZeroToOne()
    {
        transform.localScale = Vector3.zero;
        yield return null;
        transform.DOScale(1, scaleDuration).SetEase(ease);

    }

}
