using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;
using DG.Tweening;
public class MainCamera : ClickMouseController
{
    private void Start()
    {
        this.RegisterEvent<ShakeEvent>(OnShake).UnRegisterOnDestroy(gameObject);
    }
    void OnShake(ShakeEvent e)
    {
        var zfactor = transform.position.z;
        var path = new Vector3[4] { new Vector3(-0.05f, -0.05f, zfactor),
            new Vector3(-0.05f, 0.05f, zfactor),
            new Vector3(0.05f, 0.05f, zfactor),
            new Vector3(0, 0, zfactor) };
        transform.DOPath(path, 0.2f);
    }
}
