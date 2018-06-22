using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace parserVideo
{
    public interface IMainForm
    {
        event EventHandler<string> ChangeCurentUrl;
        event EventHandler<string> ChangeCurentFolder;
        event EventHandler<string> SaveAll;
        event EventHandler StartParsClick;
        event EventHandler StopParsClick;
        void SetPanel(UserControl value);
    }

    public partial class MainForm : Form, IMainForm
    {

        public string CurentUrlByParser { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            textBoxUrl.TextChanged += TextBoxUrl_TextChanged;
        }

        public void SetPanel(UserControl value)
        {
            panel1.Controls.Add(value);
        }

        public event EventHandler<string> ChangeCurentUrl;
        public event EventHandler<string> ChangeCurentFolder;
        public event EventHandler<string> SaveAll;
        public event EventHandler StartParsClick;
        public event EventHandler StopParsClick;

        private void TextBoxUrl_TextChanged(object sender, EventArgs e)
        {
            CurentUrlByParser = textBoxUrl.Text;
            ChangeCurentUrl(this, CurentUrlByParser);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonStartPars_Click(object sender, EventArgs e)
        {
            StartParsClick?.Invoke(this, EventArgs.Empty);
        }

        private void buttonStopPars_Click(object sender, EventArgs e)
        {
            StopParsClick?.Invoke(this, EventArgs.Empty);
        }

        private void buttonSaveFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdDialog= new FolderBrowserDialog();
            if (fdDialog.ShowDialog() ==DialogResult.OK)
            {
                ChangeCurentFolder?.Invoke(this, fdDialog.SelectedPath);
            }
        }

        private void buttonAutoSave_Click(object sender, EventArgs e)
        {
          FolderBrowserDialog fdDialog = new FolderBrowserDialog();
            if (fdDialog.ShowDialog() == DialogResult.OK)
            {
                SaveAll?.Invoke(this, fdDialog.SelectedPath);
            }
        }

    }
}