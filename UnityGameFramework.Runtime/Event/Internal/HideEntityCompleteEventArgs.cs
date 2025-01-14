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
    /// 隐藏实体完成事件。
    /// </summary>
    public sealed class HideEntityCompleteEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化隐藏实体完成事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public HideEntityCompleteEventArgs(GameFramework.Entity.HideEntityCompleteEventArgs e)
        {
            EntityId = e.EntityId;
            UserData = e.UserData;
        }

        /// <summary>
        /// 获取隐藏实体完成事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.HideEntityComplete;
            }
        }

        /// <summary>
        /// 获取实体编号。
        /// </summary>
        public int EntityId
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
