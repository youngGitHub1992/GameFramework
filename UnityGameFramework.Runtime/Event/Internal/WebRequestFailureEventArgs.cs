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
    /// Web 请求失败事件。
    /// </summary>
    public sealed class WebRequestFailureEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化 Web 请求失败事件的新实例。
        /// </summary>
        /// <param name="e">内部事件。</param>
        public WebRequestFailureEventArgs(GameFramework.WebRequest.WebRequestFailureEventArgs e)
        {
            WWWFormInfo wwwFormInfo = e.UserData as WWWFormInfo;
            SerialId = e.SerialId;
            WebRequestUri = e.WebRequestUri;
            ErrorMessage = e.ErrorMessage;
            UserData = wwwFormInfo.UserData;
        }

        /// <summary>
        /// 获取 Web 请求失败事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return (int)EventId.WebRequestFailure;
            }
        }

        /// <summary>
        /// 获取 Web 请求任务的序列编号。
        /// </summary>
        public int SerialId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取 Web 请求地址。
        /// </summary>
        public string WebRequestUri
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取错误信息。
        /// </summary>
        public string ErrorMessage
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
