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
    /// 资源更新开始事件。
    /// </summary>
    public sealed class ResourceUpdateStartEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化资源更新开始事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public ResourceUpdateStartEventArgs(GameFramework.Resource.ResourceUpdateStartEventArgs e)
        {
            Name = e.Name;
            DownloadPath = e.DownloadPath;
            DownloadUri = e.DownloadUri;
            CurrentLength = e.CurrentLength;
            ZipLength = e.ZipLength;
            RetryCount = e.RetryCount;
        }

        /// <summary>
        /// 获取资源更新开始事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.ResourceUpdateStart;
            }
        }

        /// <summary>
        /// 获取资源名称。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源下载后存放路径。
        /// </summary>
        public string DownloadPath
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载地址。
        /// </summary>
        public string DownloadUri
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前下载大小。
        /// </summary>
        public int CurrentLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取压缩包大小。
        /// </summary>
        public int ZipLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取已重试下载次数。
        /// </summary>
        public int RetryCount
        {
            get;
            private set;
        }
    }
}
