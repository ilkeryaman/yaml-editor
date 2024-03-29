﻿using YAMLEditor.ContentEditor.Model;
using YAMLEditor.ContentEditor.Services.Interfaces;
using YAMLEditor.ContentEditor.Services.YamlDotNet;
using YAMLEditor.Exception.Constants;
using YAMLEditor.Exception.Model;
using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services;
using YAMLEditor.Node.Services.Interfaces;
using YAMLEditor.UI.Constants;
using YAMLEditor.UI.Services.Interfaces;
using YAMLEditor.UI.Services.YamlDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YAMLEditor.UI.Services
{
    class DynamicPanelGenerator
    {
        private object _data;
        private FlowLayoutPanel _panel;
        IDynamicPanelConstructor dynamicPanelConstructor;

        public DynamicPanelGenerator(FlowLayoutPanel panel, object data)
        {
            _panel = panel;
            _data = data;
            dynamicPanelConstructor = new YamlDotNetDynamicPanelConstructor(_panel);
        }

        public void ConstructDynamicPanel(string key)
        {
            _panel.Controls.Clear();
            CreateTitle(key);
            dynamicPanelConstructor.ConstructDynamicPanel(key, _data, true);
            CreateSetButton();
        }

        private void CreateTitle(string key)
        {
            string title = "[ " + key + " ]";
            ControlCreator.CreateLabel(_panel, key, title, Color.Red);
        }

        private void CreateSetButton()
        {
            if (HasEditableControl())
            {
                ControlCreator.CreateButton(_panel, FormConstants.Button.Set.Name, FormConstants.Button.Set.Text, 
                    (sender, e) => onClickSetButton(sender, e));
            }
        }

        private void onClickSetButton(object sender, EventArgs e)
        {
            TreeView treeView = (TreeView) _panel.Tag;
            YamlNode rootNode = (YamlNode) treeView.Tag;
            INodeSearcher nodeSearcher = new NodeSearcher();
            IContentChanger contentChanger = new YamlDotNetContentChanger();

            ContentEditorResult result = new ContentEditorResult();
            foreach (Control control in GetEditableControls())
            {
                string propertyName = Convert.ToString(control.Tag);
                string value = string.Empty;
                if (control is TextBox)
                {
                    value = ((TextBox) control).Text;
                }
                else if (control is ComboBox)
                {
                    value = Convert.ToString(((ComboBox)control).SelectedItem);
                }
                
                YamlNode foundNode = nodeSearcher.SearchNode(rootNode, propertyName);
                result = contentChanger.ChangeContent(foundNode, value);
                if (result.IsSucceded == false)
                {
                    if (result.Exception is ValidationException)
                    {
                        ControlCreator.ShowExceptionMessage(result.Exception.Message, ExceptionMessage.Error);
                    }
                    else
                    {
                        ControlCreator.ShowImplementationError(result.Exception.Message);
                    }
                    break;
                }
            }

            ManageResultLabel(result);
        }

        private void ManageResultLabel(ContentEditorResult result)
        {
            string key = FormConstants.Prefix.Label_Name + FormConstants.Label.ValueSet.Name;
            if (_panel.Controls.ContainsKey(key))
            {
                _panel.Controls.RemoveByKey(key);
            }

            if (result.IsSucceded)
            {
                ControlCreator.CreateLabel(_panel, FormConstants.Label.ValueSet.Name, FormConstants.Label.ValueSet.Text, Color.Green);
            }
        }

        private bool HasEditableControl()
        {
            foreach (Control control in _panel.Controls)
            {
                if (control is TextBox || control is ComboBox)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Control> GetEditableControls()
        {
            List<Control> controlList = new List<Control>();
            foreach (Control control in _panel.Controls)
            {
                if (control is TextBox)
                {
                    controlList.Add((TextBox)control);
                }
                else if (control is ComboBox)
                {
                    controlList.Add((ComboBox)control);
                }
            }
            return controlList;
        }
    }
}
