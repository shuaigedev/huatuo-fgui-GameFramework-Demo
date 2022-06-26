# huatuo-fgui-GameFramework-Demo
huatuo-fgui-GameFramework-Demo
GF框架下集成FGUI+huatuo+URP
以及简单的一个大厅大富翁游戏+小游戏的Play Dev

1.GameFramework有一定使用成本，具体看该框架的相关教程。

2.热更新web服务器用的是windows下的HFS，用来模拟huatuo的dll热更新下载

感谢以下大佬的帮助：

huatuo群中的Ron & 冬瓜 & walon

以及以下开源项目的帮助：

GameFramework：

https://github.com/EllanJiang/GameFramework/fork

GF集成huatuo：

https://github.com/GREAT1217/StarForce_HuaTuo

一个集成FGUI的跳跳小游戏：

https://github.com/Awenc/Jump

开发日志，其中卡了最久的是集成huatuo时，动态创建的Prefabs中挂载hotfix代码miss的问题：

需要在Prefab上挂脚本的热更dll名称列表，不需要挂到Prefab上的脚本可以不放在这里

public static List<string> s_monoHotUpdateDllNames = new List<string>()
{
    "Game.Hotfix.dll",
};
