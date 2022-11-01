using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class ShakeCmd : BaseCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<ShakeEvent>();
    }

    protected override void OnInit()
    {

    }
}

public class ShakeEvent
{
    public bool isMiss;
}
