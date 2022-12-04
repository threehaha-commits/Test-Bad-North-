using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUIButton : MonoBehaviour
{
    private bool _isPause;
    private List<IPause> _pauseList = new();
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void AddPauseUnit(IPause pause)
    {
        _pauseList.Add(pause);
    }
    
    public void Pause()
    {
        _isPause = !_isPause;
        foreach (var pause in _pauseList)
        {
            pause.isPause = _isPause;
        }
        ChangeColor();
    }

    private void ChangeColor()
    {
        _image.color = _isPause ? Color.red :  Color.white;
    }
}