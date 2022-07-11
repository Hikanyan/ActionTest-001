using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [Tooltip("�A�C�e������������̌��ʉ�")]
    [SerializeField] AudioClip _audio;
    public abstract void Activate();

    private void OnTriggerEnter(Collider other)
    {
        if (_audio)
        {
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
        }
    }
}
