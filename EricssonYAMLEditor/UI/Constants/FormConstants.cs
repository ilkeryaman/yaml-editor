
using EricssonYAMLEditor.Node.Constants;

namespace EricssonYAMLEditor.UI.Constants
{
    struct FormConstants
    {
        public const string File_Filter_Text = "YAML Ain't Markup Language|*.yml;*.yaml";

        public struct Prefix
        {
            public const string Label_Name = "lbl_";
            public const string TextBox_Name = "txtBox_";
            public const string TextArea_Name = "txtArea_";
            public const string Button_Name = "btn_";
            public const string ComboBox_Name = "comboBox_";
        }

        public struct ToolStripMenuItem
        {
            public struct Add
            {
                public const string Text = "Add";
            }

            public struct Remove
            {
                public const string Text = "Remove";
            }
        }

        public struct Label
        {
            public struct CopyItemTemplateFrom
            {
                public const string Name = "lbl_CopyItemTemplate";
                public const string Text = "Copy item template from:";
            }

            public struct Content
            {
                public const string Name = "lbl_Content";
                public const string Text = "Content:";
            }

            public struct ValueSet
            {
                public const string Name = "ValueSet";
                public const string Text = "Value Set.";
            }
        }

        public struct Button
        {
            public struct Set
            {
                public const string Name = "Set";
                public const string Text = "Set Value(s)";
            }

            public struct Prev
            {
                public struct Name
                {
                    public const string Empty = "<<";
                    public const string Networks = "<< " + PropertyKey.FullName.networks;
                    public const string ControlPlane = "<< " + PropertyKey.FullName.controlplane;
                }
            }

            public struct Next
            {
                public struct Name
                {
                    public const string Empty = ">>";
                    public const string ControlPlane = ">> " + PropertyKey.FullName.controlplane;
                    public const string WorkerPools = ">> " + PropertyKey.FullName.worker_pools;
                }
            }

            public struct AddNewItem
            {
                public const string Text = "Add New Item";
            }
        }
    }
}
