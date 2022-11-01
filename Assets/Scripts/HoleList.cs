using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

// 所有洞穴
public class HoleList : ClickMouseController
{
    // Start is called before the first frame update
    void Start()
    {
        var holes = transform.GetComponentsInChildren<Hole>();
        foreach(var h in holes)
        {
            _holeList.Add(h);
        }
        this.RegisterEvent<GameStartEvent>(OnStartGame).UnRegisterOnDestroy(gameObject);
        this.RegisterEvent<GameOverEvent>(OnGameOver).UnRegisterOnDestroy(gameObject);
    }

    void OnStartGame(GameStartEvent e)
    {
        StartCoroutine("AppearMole");
    }

    void OnGameOver(GameOverEvent e)
    {
        StopCoroutine("AppearMole");
    }

    IEnumerator AppearMole()
    {
        while(true)
        {
            // 随机显示地鼠
            var hole = GetRandomHole();
            if (hole != null)
            {
                hole.Show();
            }

            int delayTime = this.GetModel<GameModel>().DelayTime.Value;
            yield return new WaitForSeconds(delayTime);
        }
        yield return 0;
    }

    // 拿随机洞穴
    public Hole GetRandomHole()
    {
        var match = _holeList.FindAll(h=> { return h.GetState() == Hole.HoleState.eNull; });
        int choose = UnityEngine.Random.Range(0, match.Count);
        if (match.Count > 0)
            return match[choose];
        return null;
    }

    private List<Hole> _holeList = new List<Hole>();
}
