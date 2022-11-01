using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class HitCmd : BaseCommand
{
    public HitCmd(Hole hole)
    {
        _hole = hole;
    }

    protected override void OnExecute()
    {
        this.SendEvent<HitEvent>(new HitEvent { hole = _hole});
    }

    protected override void OnInit()
    {

    }

    Hole _hole;
}

public class HitEvent
{
    public Hole hole;
}
