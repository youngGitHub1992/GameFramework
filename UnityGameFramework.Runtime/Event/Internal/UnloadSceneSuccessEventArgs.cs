﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 卸载场景成功事件。
    /// </summary>
    public sealed class UnloadSceneSuccessEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化卸载场景成功事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public UnloadSceneSuccessEventArgs(GameFramework.Scene.UnloadSceneSuccessEventArgs e)
        {
            SceneName = e.SceneName;
            UserData = e.UserData;
        }

        /// <summary>
        /// 获取加载场景成功事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.UnloadSceneSuccess;
            }
        }

        /// <summary>
        /// 获取场景名称。
        /// </summary>
        public string SceneName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义数据。
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }
    }
}
