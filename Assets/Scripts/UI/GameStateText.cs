using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YFrameWork;

public class GameStateText : ClickMouseController
{
    void Awake()
    {
        _text = GetComponent<Text>();
        _text.text = "等待中";
        this.RegisterEvent<GameStartEvent>(OnGameStart).UnRegisterOnDestroy(gameObject);
        this.RegisterEvent<GameOverEvent>(OnGameOver).UnRegisterOnDestroy(gameObject);
        StartCoroutine("WaitForStart");
    }

    IEnumerator WaitForStart()
    {
        while(true)
        {
            _text.text = _waitTime.ToString();

            int step = 1;
            yield return new WaitForSeconds(step);
            _waitTime -= step;
            if(_waitTime == 0)
            {
                this.SendCommand<StartGameCmd>();
                break;
            }
        }
        yield return 0;
    }

    void OnGameStart(GameStartEvent e)
    {
        _text.text = "游戏中";
    }

    void OnGameOver(GameOverEvent e)
    {
        _text.text = "游戏结束";
    }

    Text _text;
    public int _waitTime = 3;
}
