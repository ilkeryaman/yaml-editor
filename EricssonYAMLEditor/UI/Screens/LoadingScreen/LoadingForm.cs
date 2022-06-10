using EricssonYAMLEditor.UI.Constants;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Screens.LoadingScreen
{
    public partial class LoadingForm : Form
    {
        private int _intervalMillisecond = 1000;

        public LoadingForm()
        {
            InitializeComponent();
            InitComponent();
        }

        public LoadingForm(int intervalMillisecond) : this()
        {
            _intervalMillisecond = intervalMillisecond;
        }

        private void InitComponent()
        {
            this.label1.Text = FormConstants.Label.Loading.Text;
        }

        private void LoadingForm_Load(object sender, System.EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = _intervalMillisecond;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
