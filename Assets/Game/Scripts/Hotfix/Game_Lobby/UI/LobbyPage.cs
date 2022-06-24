using FairyGUI;
using Game;
using Game.Hotfix;
using GameFramework;
using Lobby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class LobbyPage : FGuiForm
{
    UI_Lobby ui;
    UI_bg bg;
    UI_CompGameDice dice;
    int firstIndex = 0;
    int moveNodeCount = 0;
    int nodeCount = 0;
    bool beginJump = false;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        ui = UI.asCom as UI_Lobby;
        bg = ui.m_bg.component as UI_bg;
        dice = ui.m_sider.component as UI_CompGameDice;
        nodeCount = bg.m_nodes.numChildren;
        for (int i = 1; i < 7; i++)
        {
            dice.GetChild("saizi"+i).visible = false;
        }
        //bg.m_nodes.AddChild(bg.m_Player);
        ui.m_sider.onClick.Add(() =>
        {
            if (!beginJump)
            {
                beginJump = true;
                moveNodeCount = Random.Range(1, 6);
                for (int i = 0; i < 7; i++)
                {
                    dice.GetChild("saizi" + i).visible = false;
                }
                dice.GetChild("saizi" + moveNodeCount).visible = true;
                ToNextNode();
            }
        });

        ui.m_comp_userInfo.onClick.Add(() =>
        {
            GameHotfixEntry.OpenApp("com.lyamiwallet");
        });
    }

    private void ToNextNode()
    {
        if (!beginJump)
            return;
        var targetobj = bg.m_nodes.GetChildAt(firstIndex);
        Vector2 topos = bg.m_nodes.TransformPoint(targetobj.xy, bg.m_Player.parent);
        topos.y -= 120;
        topos.x -= 120;
        
        bg.m_Player.TweenMove(topos, 0.5f).OnComplete(() =>
        {
            topos.x += 120;
            topos.y += 120;
            bg.m_Player.TweenMove(topos, 0.5f);
        });
        bg.m_Player.TweenResize(targetobj.size * 2f, 0.5f).OnComplete(() =>
        {
            bg.m_Player.TweenResize(targetobj.size, 0.5f).OnComplete(()=> {
                firstIndex++;
                if (firstIndex >= nodeCount)
                {
                    firstIndex = 0;
                }
                moveNodeCount--;
                if (moveNodeCount == 0)
                {
                    beginJump = false;
                    //if (Random.Range(1, 6) == 3)
                    {
                        Visible = false;
                        Game.GameEntry.Event.Fire(this, ReferencePool.Acquire<NextGameEventArgs>().Fill(1));
                    }
                }
                else
                {
                    ToNextNode();
                }
            });
        });
    }

}
