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
    /// 打开界面时加载依赖资源事件。
    /// </summary>
    public sealed class OpenUIFormDependencyAssetEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化打开界面时加载依赖资源事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public OpenUIFormDependencyAssetEventArgs(GameFramework.UI.OpenUIFormDependencyAssetEventArgs e)
        {
            UIFormTypeId = e.UIFormTypeId;
            UIFormAssetName = e.UIFormAssetName;
            UIGroupName = e.UIGroupName;
            PauseCoveredUIForm = e.PauseCoveredUIForm;
            DependencyAssetName = e.DependencyAssetName;
            LoadedCount = e.LoadedCount;
            TotalCount = e.TotalCount;
            UserData = e.UserData;
        }

        /// <summary>
        /// 获取打开界面时加载依赖资源事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.OpenUIFormDependencyAsset;
            }
        }

        /// <summary>
        /// 获取界面类型编号。
        /// </summary>
        public int UIFormTypeId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取界面资源名称。
        /// </summary>
        public string UIFormAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取界面组名称。
        /// </summary>
        public string UIGroupName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取是否暂停被覆盖的界面。
        /// </summary>
        public bool PauseCoveredUIForm
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取被加载的依赖资源名称。
        /// </summary>
        public string DependencyAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前已加载依赖资源数量。
        /// </summary>
        public int LoadedCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取总共加载依赖资源数量。
        /// </summary>
        public int TotalCount
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
