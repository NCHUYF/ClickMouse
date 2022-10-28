using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YFrameWork;

public class TimeText : ClickMouseController
{
    void Awake()
    {
        _text = this.GetComponent<Text>();
        _text.text = "剩余时间：" + (int)_remainTime;
        this.RegisterEvent<GameStartEvent>(OnGameStart).UnRegisterOnDestroy(gameObject);
    }

    void OnGameStart(GameStartEvent e)
    {
        StartCoroutine("SubTime");
    }

    IEnumerator SubTime()
    {
        while (true)
        {
            if ((int)_remainTime > 0)
            {
                _text.text = "剩余时间：" + (int)_remainTime;
            }
            else
            {
                _text.text = "剩余时间：" + 0;
                break;
            }

            int step = 1;
            _remainTime -= step;
            yield return new WaitForSeconds(step);
        }
        this.SendCommand<GameOverCmd>();
        yield return 0;
    }

    Text _text;
    public float _remainTime = 30.0f;
}
