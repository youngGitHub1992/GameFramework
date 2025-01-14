﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private sealed class ProfilerInformationWindow : ScrollableDebuggerWindowBase
        {
            private const int MBSize = 1024 * 1024;

            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Profiler Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Supported:", Profiler.supported.ToString());
                    DrawItem("Enabled:", Profiler.enabled.ToString());
                    DrawItem("Enable Binary Log:", Profiler.enableBinaryLog ? string.Format("True, {0}", Profiler.logFile) : "False");
                    DrawItem("Max Samples Number Per Frame:", Profiler.maxNumberOfSamplesPerFrame.ToString());
                    DrawItem("Mono Used Size:", string.Format("{0} MB", (Profiler.GetMonoUsedSize() / (float)MBSize).ToString("F3")));
                    DrawItem("Mono Heap Size:", string.Format("{0} MB", (Profiler.GetMonoHeapSize() / (float)MBSize).ToString("F3")));
                    DrawItem("Used Heap Size:", string.Format("{0} MB", (Profiler.usedHeapSize / (float)MBSize).ToString("F3")));
                    DrawItem("Total Allocated Memory:", string.Format("{0} MB", (Profiler.GetTotalAllocatedMemory() / (float)MBSize).ToString("F3")));
                    DrawItem("Total Reserved Memory:", string.Format("{0} MB", (Profiler.GetTotalReservedMemory() / (float)MBSize).ToString("F3")));
                    DrawItem("Total Unused Reserved Memory:", string.Format("{0} MB", (Profiler.GetTotalUnusedReservedMemory() / (float)MBSize).ToString("F3")));
                }
                GUILayout.EndVertical();
            }
        }
    }
}
