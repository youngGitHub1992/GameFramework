﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.ObjectPool;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private sealed class ObjectPoolInformationWindow : ScrollableDebuggerWindowBase
        {
            private ObjectPoolComponent m_ObjectPoolComponent = null;

            public override void Initialize(params object[] args)
            {
                m_ObjectPoolComponent = GameEntry.GetComponent<ObjectPoolComponent>();
                if (m_ObjectPoolComponent == null)
                {
                    Log.Fatal("Object pool component is invalid.");
                    return;
                }
            }

            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Object Pool Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Object Pool Count", m_ObjectPoolComponent.Count.ToString());
                }
                GUILayout.EndVertical();
                ObjectPoolBase[] objectPools = m_ObjectPoolComponent.GetAllObjectPools(true);
                foreach (ObjectPoolBase objectPool in objectPools)
                {
                    DrawObjectPool(objectPool);
                }
            }

            private void DrawObjectPool(ObjectPoolBase objectPool)
            {
                GUILayout.Label(string.Format("<b>Object Pool: {0}</b>", string.IsNullOrEmpty(objectPool.Name) ? "<Unnamed>" : objectPool.Name));
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Type", objectPool.ObjectType.FullName);
                    DrawItem("Auto Release Interval", objectPool.AutoReleaseInterval.ToString());
                    DrawItem("Capacity", string.Format("{0} / {1} / {2}", objectPool.CanReleaseCount.ToString(), objectPool.Count.ToString(), objectPool.Capacity.ToString()));
                    DrawItem("Expire Time", objectPool.ExpireTime.ToString());
                    DrawItem("Priority", objectPool.Priority.ToString());
                    ObjectInfo[] objectInfos = objectPool.GetAllObjectInfos();
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("<b>Name</b>");
                        GUILayout.Label("<b>Locked</b>", GUILayout.Width(60f));
                        GUILayout.Label(objectPool.AllowMultiSpawn ? "<b>Count</b>" : "<b>In Use</b>", GUILayout.Width(60f));
                        GUILayout.Label("<b>Priority</b>", GUILayout.Width(60f));
                        GUILayout.Label("<b>Last Use Time</b>", GUILayout.Width(120f));
                    }
                    GUILayout.EndHorizontal();

                    if (objectInfos.Length > 0)
                    {
                        foreach (ObjectInfo objectInfo in objectInfos)
                        {
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Label(objectInfo.Name);
                                GUILayout.Label(objectInfo.Locked.ToString(), GUILayout.Width(60f));
                                GUILayout.Label(objectPool.AllowMultiSpawn ? objectInfo.SpawnCount.ToString() : objectInfo.IsInUse.ToString(), GUILayout.Width(60f));
                                GUILayout.Label(objectInfo.Priority.ToString(), GUILayout.Width(60f));
                                GUILayout.Label(objectInfo.LastUseTime.ToString("yyyy-MM-dd HH:mm:ss"), GUILayout.Width(120f));
                            }
                            GUILayout.EndHorizontal();
                        }
                    }
                    else
                    {
                        GUILayout.Label("<i>Object Pool is Empty ...</i>");
                    }
                }
                GUILayout.EndVertical();
            }
        }
    }
}
