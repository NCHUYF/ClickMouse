using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class GameModel : BaseModel, IModel
{
    protected override void OnInit()
    {
        Score.Register(OnScoreModify);
    }

    void OnScoreModify(int score)
    {
        this.SendEvent(new ScoreModifyEvent { newScore = score});
    }

    public BindableProperty<int> Score = new BindableProperty<int>();
    public BindableProperty<int> StayTime = new BindableProperty<int>(3);
    public BindableProperty<int> DelayTime = new BindableProperty<int>(1);
}
