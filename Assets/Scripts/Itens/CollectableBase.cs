using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    protected virtual void HideItens()
    {
        if (graphicItem != null)graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
        if(audioSource != null) audioSource.Play();
        Debug.Log("Collect");
        PlayerController.Instance.Bounce();
    }
}

