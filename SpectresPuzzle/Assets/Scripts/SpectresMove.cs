using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectresMove : MonoBehaviour
{
    [SerializeField] NextSpectres[] _nextSpectres = new NextSpectres[14];

    void Start()
    {
        
    }

    public void ShowNextSpectres(int num)
    {
        for (int i = 0; i < _nextSpectres.Length; i++)
        {
            if (_nextSpectres[i].SpectresID == num)
                _nextSpectres[i].ShowNext();
            else
                _nextSpectres[i].HideSprite();
        }
    }
}
