using YAMLEditor.UI.Constants;

namespace YAMLEditor.UI.Services
{
    class PageManager
    {
        private int _pageIndex;
        private Form1 _form;

        public PageManager(Form1 form)
        {
            _pageIndex = 0;
            _form = form;
        }

        public void Reset()
        {
            _pageIndex = 0;
            ManagePage();
        }

        public void Prev()
        {
            _pageIndex--;
            ManagePage();
        }

        public void Next()
        {
            _pageIndex++;
            ManagePage();
        }

        private void ManagePage()
        {
            ClearFlowLayoutPanel();
            ManageVisibility();
        }

        private void ClearFlowLayoutPanel()
        {
            _form.FlowLayoutPanel1.Controls.Clear();
        }

        private void ManageVisibility()
        {
            if (_pageIndex == 0)
            {
                _form.Button_Prev.Text = FormConstants.Button.Prev.Name.Empty;
                _form.Button_Prev.Visible = true;
                _form.Button_Prev.Enabled = false;
                _form.Button_Next.Text = FormConstants.Button.Next.Name.ControlPlane;
                _form.Button_Next.Visible = true;
                _form.Button_Next.Enabled = true;
                _form.TreeView_Networks.Visible = true;
                _form.TreeView_Control_Plane.Visible = false;
                _form.TreeView_Worker_Pools.Visible = false;
                _form.FlowLayoutPanel1.Tag = _form.TreeView_Networks;
            }
            else if(_pageIndex == 1)
            {
                _form.Button_Prev.Text = FormConstants.Button.Prev.Name.Networks;
                _form.Button_Prev.Visible = true;
                _form.Button_Prev.Enabled = true;
                _form.Button_Next.Text = FormConstants.Button.Next.Name.WorkerPools;
                _form.Button_Next.Visible = true;
                _form.Button_Next.Enabled = true;
                _form.TreeView_Networks.Visible = false;
                _form.TreeView_Control_Plane.Visible = true;
                _form.TreeView_Worker_Pools.Visible = false;
                _form.FlowLayoutPanel1.Tag = _form.TreeView_Control_Plane;
            }
            else if (_pageIndex == 2)
            {
                _form.Button_Prev.Text = FormConstants.Button.Prev.Name.ControlPlane;
                _form.Button_Prev.Visible = true;
                _form.Button_Prev.Enabled = true;
                _form.Button_Next.Text = FormConstants.Button.Next.Name.Empty;
                _form.Button_Next.Visible = true;
                _form.Button_Next.Enabled = false;
                _form.TreeView_Networks.Visible = false;
                _form.TreeView_Control_Plane.Visible = false;
                _form.TreeView_Worker_Pools.Visible = true;
                _form.FlowLayoutPanel1.Tag = _form.TreeView_Worker_Pools;
            }
        }
    }
}
