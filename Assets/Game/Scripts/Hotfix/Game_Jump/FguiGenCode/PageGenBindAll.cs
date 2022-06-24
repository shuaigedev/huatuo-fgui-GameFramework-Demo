using Comment;
using GameOverPage;
using Lobby;
using LoginPage;
using MainPage;
using MenuPage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageGenBindAll 
{
    public static void BindAll()
    {
        CommentBinder.BindAll();
        MenuPageBinder.BindAll();
        LoginPageBinder.BindAll();
        MainPageBinder.BindAll();
        GameOverPageBinder.BindAll();

        LobbyBinder.BindAll();
    }
}
