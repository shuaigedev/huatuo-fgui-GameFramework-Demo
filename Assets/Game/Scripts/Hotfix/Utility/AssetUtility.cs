//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;

namespace Game.Hotfix
{
    public static class AssetUtility
    {

        public static string GetConfigAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Game/Configs/Runtime/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDataTableAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Game/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDictionaryAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Game/Localization/{0}/Dictionaries/{1}.{2}", GameEntry.Localization.Language, assetName, fromBytes ? "bytes" : "xml");
        }

        public static string GetFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Game/Fonts/{0}.ttf", assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Game/Res/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Game/Res/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Game/Res/Sounds/{0}.wav", assetName);
        }

        public static string GetEntityAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Game/Res/Entities/{0}.prefab", assetName);
        }

        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Game/Res/UI/UIForms/{0}.prefab", assetName);
        }

        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Game/Res/UI/UISounds/{0}.wav", assetName);
        }
    }
}
