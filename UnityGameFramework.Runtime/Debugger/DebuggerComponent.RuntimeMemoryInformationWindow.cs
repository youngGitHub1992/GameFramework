﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:i@jiangyin.me
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private sealed partial class RuntimeMemoryInformationWindow<T> : ScrollableDebuggerWindowBase where T : UnityEngine.Object
        {
            private const int ShowSampleCount = 300;

            private DateTime m_SampleTime = DateTime.MinValue;
            private int m_SampleSize = 0;
            private int m_DuplicateSimpleCount = 0;
            private int m_DuplicateSampleSize = 0;
            private List<Sample> m_Samples = new List<Sample>();

            protected override void OnDrawScrollableWindow()
            {
                string typeName = typeof(T).Name;
                GUILayout.Label(string.Format("<b>{0} Runtime Memory Information</b>", typeName));
                GUILayout.BeginVertical("box");
                {
                    if (GUILayout.Button(string.Format("Take Sample for {0}", typeName), GUILayout.Height(30f)))
                    {
                        TakeSample();
                    }

                    if (m_SampleTime <= DateTime.MinValue)
                    {
                        GUILayout.Label(string.Format("<b>Please take sample for {0} first.</b>", typeName));
                    }
                    else
                    {
                        if (m_DuplicateSimpleCount > 0)
                        {
                            GUILayout.Label(string.Format("<b>{0} {1}s ({2}) obtained at {3}, while {4} {1}s ({5}) might be duplicated.</b>", m_Samples.Count.ToString(), typeName, GetSizeString(m_SampleSize), m_SampleTime.ToString("yyyy-MM-dd HH:mm:ss"), m_DuplicateSimpleCount.ToString(), GetSizeString(m_DuplicateSampleSize)));
                        }
                        else
                        {
                            GUILayout.Label(string.Format("<b>{0} {1}s ({2}) obtained at {3}.</b>", m_Samples.Count.ToString(), typeName, GetSizeString(m_SampleSize), m_SampleTime.ToString("yyyy-MM-dd HH:mm:ss")));
                        }

                        if (m_Samples.Count > 0)
                        {
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Label(string.Format("<b>{0} Name</b>", typeName));
                                GUILayout.Label("<b>Type</b>", GUILayout.Width(240f));
                                GUILayout.Label("<b>Size</b>", GUILayout.Width(80f));
                            }
                            GUILayout.EndHorizontal();
                        }

                        int count = 0;
                        foreach (Sample sample in m_Samples)
                        {
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Label(sample.Highlight ? string.Format("<color=yellow>{0}</color>", sample.Name) : sample.Name);
                                GUILayout.Label(sample.Highlight ? string.Format("<color=yellow>{0}</color>", sample.Type) : sample.Type, GUILayout.Width(240f));
                                GUILayout.Label(sample.Highlight ? string.Format("<color=yellow>{0}</color>", GetSizeString(sample.Size)) : GetSizeString(sample.Size), GUILayout.Width(80f));
                            }
                            GUILayout.EndHorizontal();

                            count++;
                            if (count >= ShowSampleCount)
                            {
                                break;
                            }
                        }
                    }
                }
                GUILayout.EndVertical();
            }

            private void TakeSample()
            {
                m_SampleTime = DateTime.Now;
                m_SampleSize = 0;
                m_DuplicateSimpleCount = 0;
                m_DuplicateSampleSize = 0;
                m_Samples.Clear();

                T[] samples = Resources.FindObjectsOfTypeAll<T>();
                foreach (T sample in samples)
                {
                    int sampleSize = Profiler.GetRuntimeMemorySize(sample);
                    m_SampleSize += sampleSize;
                    m_Samples.Add(new Sample(sample.name, sample.GetType().Name, sampleSize));
                }

                m_Samples.Sort(SampleComparer);

                for (int i = 1; i < m_Samples.Count; i++)
                {
                    if (m_Samples[i].Name == m_Samples[i - 1].Name && m_Samples[i].Type == m_Samples[i - 1].Type && m_Samples[i].Size == m_Samples[i - 1].Size)
                    {
                        m_Samples[i].Highlight = true;
                        m_DuplicateSimpleCount++;
                        m_DuplicateSampleSize += m_Samples[i].Size;
                    }
                }
            }

            private string GetSizeString(int size)
            {
                if (size < 1024)
                {
                    return string.Format("{0} Bytes", size.ToString());
                }

                if (size < 1024 * 1024)
                {
                    return string.Format("{0} KB", (size / 1024f).ToString("F2"));
                }

                if (size < 1024 * 1024 * 1024)
                {
                    return string.Format("{0} MB", (size / 1024f / 1024f).ToString("F2"));
                }

                return string.Format("{0} GB", (size / 1024f / 1024f / 1024f).ToString("F2"));
            }

            private int SampleComparer(Sample a, Sample b)
            {
                int result = b.Size.CompareTo(a.Size);
                if (result != 0)
                {
                    return result;
                }

                result = a.Type.CompareTo(b.Type);
                if (result != 0)
                {
                    return result;
                }

                return a.Name.CompareTo(b.Name);
            }
        }
    }
}
