using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class ClickMouseApp : BaseApp<ClickMouseApp>
{
    private ClickMouseApp() { }
    protected override void InitApp()
    {
        RegisterModel(new GameModel());
    }
}
