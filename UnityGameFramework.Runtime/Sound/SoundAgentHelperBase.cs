﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Entity;
using GameFramework.Sound;
using System;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 声音代理辅助器基类。
    /// </summary>
    public abstract class SoundAgentHelperBase : MonoBehaviour, ISoundAgentHelper
    {
        /// <summary>
        /// 获取当前是否正在播放。
        /// </summary>
        public abstract bool IsPlaying
        {
            get;
        }

        /// <summary>
        /// 获取或设置播放位置。
        /// </summary>
        public abstract float Time
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置是否静音。
        /// </summary>
        public abstract bool Mute
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置是否循环播放。
        /// </summary>
        public abstract bool Loop
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置声音优先级。
        /// </summary>
        public abstract int Priority
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置音量大小。
        /// </summary>
        public abstract float Volume
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置声音音调。
        /// </summary>
        public abstract float Pitch
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置声音立体声声相。
        /// </summary>
        public abstract float PanStereo
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置声音空间混合量。
        /// </summary>
        public abstract float SpatialBlend
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置声音最大距离。
        /// </summary>
        public abstract float MaxDistance
        {
            get;
            set;
        }

        /// <summary>
        /// 重置声音代理事件。
        /// </summary>
        public abstract event EventHandler<ResetSoundAgentEventArgs> ResetSoundAgent;

        /// <summary>
        /// 播放声音。
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// 停止播放声音。
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// 暂停播放声音。
        /// </summary>
        public abstract void Pause();

        /// <summary>
        /// 恢复播放声音。
        /// </summary>
        public abstract void Resume();

        /// <summary>
        /// 重置声音代理辅助器。
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// 设置声音资源。
        /// </summary>
        /// <param name="soundAsset">声音资源。</param>
        /// <returns>设置声音资源是否成功。</returns>
        public abstract bool SetSoundAsset(object soundAsset);

        /// <summary>
        /// 设置声音绑定的实体。
        /// </summary>
        /// <param name="bindingEntity">声音绑定的实体。</param>
        public abstract void SetBindingEntity(IEntity bindingEntity);
    }
}
