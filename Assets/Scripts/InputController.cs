using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class InputController : ClickMouseController
{
    private void Start()
    {
        Cursor.visible = false; //隐藏鼠标指针
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null)
            {
                return;
            }

            var hole = hit.collider.gameObject.GetComponent<Hole>();
            if (hole == null)
            {
                return;
            }

            this.SendCommand(new HitCmd(hole));
        }
    }
}
