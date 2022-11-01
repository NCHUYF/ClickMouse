using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class GameOverCmd : BaseCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<GameOverEvent>();
    }

    protected override void OnInit()
    {

    }
}

class GameOverEvent
{
}