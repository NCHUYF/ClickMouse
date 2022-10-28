using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class AddScoreCmd : BaseCommand
{
    protected override void OnExecute()
    {
        // 加分
        this.GetModel<GameModel>().Score.Value += 10;
    }

    protected override void OnInit()
    {

    }
}
