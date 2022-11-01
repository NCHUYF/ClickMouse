using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class Hammer : ClickMouseController
{

    void Start()
    {
        this.RegisterEvent<HitEvent>(OnHit).UnRegisterOnDestroy(gameObject);

        _animator = GetComponent<Animator>();
    }

    void OnHit(HitEvent e)
    {
        _animator.SetTrigger("Hit");
    }

    // 跟随鼠标
    void FollowMouse()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = transform.position.z;
        transform.position = worldPos;
    }

    void Update()
    {
        FollowMouse();
    }

    Animator _animator;
}
