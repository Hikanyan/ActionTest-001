using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [Tooltip("アイテムを取った時の効果音")]
    [SerializeField] AudioClip _audio;
    public abstract void Activate();

    private void OnTriggerEnter(Collider other)
    {
        if (_audio)
        {
            Activate();
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
        }
    }
}
