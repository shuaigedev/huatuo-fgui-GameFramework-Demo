using Game.Hotfix;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyGame : GameBase
{
    public override GameMode GameMode
    {
        get { return GameMode.Survival; }
    }
    int nextGame = 0;
    public override int NextGame { 
        get {
            return nextGame;
        }
        set
        {
            nextGame = value;
        }
    }

    public override void Initialize()
    {
        nextGame = 0;
        GameOver = false;
        base.Initialize();
    }
}
