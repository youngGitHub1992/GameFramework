﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private sealed class EnvironmentInformationWindow : ScrollableDebuggerWindowBase
        {
            private BaseComponent m_BaseComponent = null;
            private ResourceComponent m_ResourceComponent = null;

            public override void Initialize(params object[] args)
            {
                m_BaseComponent = GameEntry.GetComponent<BaseComponent>();
                if (m_BaseComponent == null)
                {
                    Log.Fatal("Base component is invalid.");
                    return;
                }

                m_ResourceComponent = GameEntry.GetComponent<ResourceComponent>();
                if (m_ResourceComponent == null)
                {
                    Log.Fatal("Resource component is invalid.");
                    return;
                }
            }

            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Environment Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Product Name:", Application.productName);
                    DrawItem("Company Name:", Application.companyName);
                    DrawItem("Bundle Identifier:", Application.bundleIdentifier);
                    DrawItem("Game Framework Version:", GameFrameworkEntry.Version);
                    DrawItem("Unity Game Framework Version:", GameEntry.Version);
                    DrawItem("Game Version:", string.Format("{0} ({1})", m_BaseComponent.GameVersion, m_BaseComponent.InternalApplicationVersion.ToString()));
                    DrawItem("Resource Version:", m_BaseComponent.EditorResourceMode ? "Unavailable in editor resource mode" : (string.IsNullOrEmpty(m_ResourceComponent.ApplicableGameVersion) ? "Unknown" : string.Format("{0} ({1})", m_ResourceComponent.ApplicableGameVersion, m_ResourceComponent.InternalResourceVersion.ToString())));
                    DrawItem("Application Version:", Application.version);
                    DrawItem("Unity Version:", Application.unityVersion);
                    DrawItem("Platform:", Application.platform.ToString());
                    DrawItem("System Language:", Application.systemLanguage.ToString());
                    DrawItem("Cloud Project Id:", Application.cloudProjectId);
                    DrawItem("Target Frame Rate:", Application.targetFrameRate.ToString());
                    DrawItem("Internet Reachability:", Application.internetReachability.ToString());
                    DrawItem("Background Loading Priority:", Application.backgroundLoadingPriority.ToString());
                    DrawItem("Is Playing:", Application.isPlaying.ToString());
                    DrawItem("Is Showing Splash Screen:", Application.isShowingSplashScreen.ToString());
                    DrawItem("Run In Background:", Application.runInBackground.ToString());
                    DrawItem("Install Mode:", Application.installMode.ToString());
                    DrawItem("Sandbox Type:", Application.sandboxType.ToString());
                    DrawItem("Is Mobile Platform:", Application.isMobilePlatform.ToString());
                    DrawItem("Is Console Platform:", Application.isConsolePlatform.ToString());
                    DrawItem("Is Editor:", Application.isEditor.ToString());
                }
                GUILayout.EndVertical();
            }
        }
    }
}
