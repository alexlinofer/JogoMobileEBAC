using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JogoMobile.Singleton;
using DG.Tweening;
using System.Linq;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<CollectableCoin> itens;

    [Header("Animation")]
    public float scaleDuration = .3f;
    public float scaleTimeBetweenPieces = .2f;
    public Ease ease = Ease.OutBounce;

    private void Start()
    {
        itens = new List<CollectableCoin>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartAnimations();
        }
    }

    public void RegisterCoin(CollectableCoin i)
    {
        if (!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }


    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }
        Sort();

        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    private void Sort()
    {
        itens = itens.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }

    public void UnRegisterCoin(CollectableCoin i)
    {
        if(itens.Contains(i))
        {itens.Remove(i);
        }
    }

}
