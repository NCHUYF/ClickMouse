using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YFrameWork;

public class Hole : ClickMouseController
{
    public enum HoleState
    {
        eNull,
        eAlive,
        eDie,
    }

    private void Start()
    {
        _moleAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        this.RegisterEvent<HitEvent>(OnHit).UnRegisterOnDestroy(gameObject);
    }

    void OnHit(HitEvent e)
    {
        if (e.hole != this)
            return;

        if (_state == HoleState.eAlive)
        {
            _moleAnimator.SetTrigger("Die");
            _state = HoleState.eDie;
            this.SendCommand<AddScoreCmd>();
            Invoke("Hide", 0.5f);
            this.SendCommand<ShakeCmd>();
            AudioManager.Instance.PlayHitAudio();
        }
        else
        {
            AudioManager.Instance.PlayErrorAudio();
        }
    }

    public void Show()
    {
        _state = HoleState.eAlive;
        _moleAnimator.SetTrigger("Show");
        WaitForHide();
    }

    public void Hide()
    {
        _state = HoleState.eNull;
        _moleAnimator.SetTrigger("Hide");
    }

    void WaitForHide()
    {
        // 地鼠停留的时间
        int stayTime = this.GetModel<GameModel>().StayTime.Value;
        Invoke("AutoHide", stayTime);
    }

    void AutoHide()
    {
        if (_state == HoleState.eAlive) Hide();
    }

    public HoleState GetState()
    {
        return _state;
    }

    Animator _moleAnimator;
    HoleState _state = HoleState.eNull;
}
