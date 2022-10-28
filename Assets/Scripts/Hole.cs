using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YFrameWork;

public class Hole : ClickMouseController
{
    private void Start()
    {
        _mole = transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update


    public void Show()
    {
        _bDie = false;
        _mole.SetActive(true);
        _mole.GetComponent<TextMeshPro>().text = "Mouse";
        WaitForHide();
    }

    public void Hide()
    {
        _bDie = true;
        _mole.SetActive(false);
    }

    void WaitForHide()
    {
        Invoke("AutoHide", 5);
    }

    void AutoHide()
    {
        if (!_bDie) Hide();
    }

    // Update is called once per frame


    private void OnMouseDown()
    {
        if (_bDie) return;
        _mole.GetComponent<TextMeshPro>().text = "Die";
        _bDie = true;
        this.SendCommand<AddScoreCmd>();
        Invoke("Hide", 0.5f);
    }

    GameObject _mole;
    bool _bDie = true;
}
