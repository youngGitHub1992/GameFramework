﻿//------------------------------------------------------------
// Game Framework v2.x
// Copyright © 2014-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 默认数据表辅助器。
    /// </summary>
    public class DefaultDataTableHelper : DataTableHelperBase
    {
        private DataTableComponent m_DataTableComponent = null;
        private ResourceComponent m_ResourceComponent = null;

        /// <summary>
        /// 加载数据表。
        /// </summary>
        /// <param name="dataTableName">数据表名称。</param>
        /// <param name="dataTableType">数据表类型。</param>
        /// <param name="dataTableNameInType">数据表类型下的名称。</param>
        /// <param name="dataTableAsset">数据表资源。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>加载是否成功。</returns>
        public override bool LoadDataTable(string dataTableName, Type dataTableType, string dataTableNameInType, object dataTableAsset, object userData)
        {
            TextAsset textAsset = dataTableAsset as TextAsset;
            if (textAsset == null)
            {
                Log.Warning("Data table asset '{0}' is invalid.", dataTableName);
                return false;
            }

            if (dataTableType == null)
            {
                Log.Warning("Data table type is invalid.");
                return false;
            }

            MethodInfo methodInfo = m_DataTableComponent.GetType().GetMethod("ReflectionCreateDataTable", BindingFlags.NonPublic | BindingFlags.Instance);
            if (methodInfo == null)
            {
                Log.Warning("Get ReflectionCreateDataTable method failure.");
                return false;
            }

            methodInfo = methodInfo.MakeGenericMethod(dataTableType);
            if (methodInfo == null)
            {
                Log.Warning("Make 'CreateDataTable<{0}>' method failure.", dataTableType.Name);
                return false;
            }

            try
            {
                methodInfo.Invoke(m_DataTableComponent, BindingFlags.InvokeMethod, null, new object[] { dataTableNameInType, textAsset.text }, null);
                return true;
            }
            catch (Exception exception)
            {
                string errorMessage = string.Format("Invoke 'CreateDataTable<{0}>' method failure with exception '{1}'.", dataTableType.FullName, string.Format("{0}\n{1}", exception.Message, exception.StackTrace));
                if (exception.InnerException != null)
                {
                    errorMessage += string.Format(" Inner exception is '{0}'.", exception.InnerException.Message);
                }

                Log.Warning(errorMessage);
                return false;
            }
        }

        /// <summary>
        /// 将要解析的数据表文本分割为数据表行文本。
        /// </summary>
        /// <param name="text">要解析的数据表文本。</param>
        /// <returns>数据表行文本。</returns>
        public override string[] SplitToDataRows(string text)
        {
            List<string> texts = new List<string>();
            string[] rowTexts = Utility.Text.SplitToLines(text);
            foreach (string rowText in rowTexts)
            {
                if (rowText.Length <= 0 || rowText[0] == '#')
                {
                    continue;
                }

                texts.Add(rowText);
            }

            return texts.ToArray();
        }

        /// <summary>
        /// 释放数据表资源。
        /// </summary>
        /// <param name="dataTableAsset">要释放的数据表资源。</param>
        public override void ReleaseDataTableAsset(object dataTableAsset)
        {
            m_ResourceComponent.Recycle(dataTableAsset);
        }

        private void Start()
        {
            m_DataTableComponent = GameEntry.GetComponent<DataTableComponent>();
            if (m_DataTableComponent == null)
            {
                Log.Fatal("Data table component is invalid.");
                return;
            }

            m_ResourceComponent = GameEntry.GetComponent<ResourceComponent>();
            if (m_ResourceComponent == null)
            {
                Log.Fatal("Resource component is invalid.");
                return;
            }
        }
    }
}
