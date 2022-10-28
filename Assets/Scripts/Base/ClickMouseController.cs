using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;
public class ClickMouseController : MonoBehaviour, IController
{
    public IApp GetApp()
    {
        return ClickMouseApp.Instance;
    }
}
