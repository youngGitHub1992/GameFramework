﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using System;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 加载数据表成功事件。
    /// </summary>
    public sealed class LoadDataTableSuccessEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化加载数据表成功事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public LoadDataTableSuccessEventArgs(GameFramework.DataTable.LoadDataTableSuccessEventArgs e)
        {
            LoadDataTableInfo loadDataTableInfo = e.UserData as LoadDataTableInfo;
            DataTableName = loadDataTableInfo.DataTableName;
            DataTableType = loadDataTableInfo.DataTableType;
            DataTableAssetName = e.DataTableAssetName;
            Duration = e.Duration;
            UserData = loadDataTableInfo.UserData;
        }

        /// <summary>
        /// 获取加载数据表成功事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.LoadDataTableSuccess;
            }
        }

        /// <summary>
        /// 获取数据表名称。
        /// </summary>
        public string DataTableName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据表类型。
        /// </summary>
        public Type DataTableType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据表资源名称。
        /// </summary>
        public string DataTableAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取加载持续时间。
        /// </summary>
        public float Duration
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
