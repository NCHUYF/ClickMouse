using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class StartGameCmd : BaseCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<GameStartEvent>();
    }

    protected override void OnInit()
    {

    }
}
