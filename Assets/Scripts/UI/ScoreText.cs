using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YFrameWork;

public class ScoreText : ClickMouseController
{
    void Start()
    {
        this.RegisterEvent<ScoreModifyEvent>(OnScoreModify);
        _text = this.GetComponent<Text>();

    }

    void OnScoreModify(ScoreModifyEvent e)
    {
        _text.text = "分数：" + e.newScore;
    }

    Text _text;
}
