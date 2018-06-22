using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileManager.BL;
using ParserCore.BL;

namespace parserVideo
{
    public interface IMainGrupBox
    {
        Image CurrentImage { get; set; }
        string CurrentListBoxText { get; set; }
        string LoadSpead { get; set; }
        int CurrentProgressBarPerceent { get; set; }
        event EventHandler EndSaveFileDialog;
        event EventHandler StopLoadClick;
        event EventHandler<string> StartLoadClick;

        void ManualLoadStarted();
        void StartSaveDialog();
    }

    public partial class MainGrupBox : UserControl, IMainGrupBox
    {

        public event EventHandler EndSaveFileDialog;
        public event EventHandler StopLoadClick;
        public event EventHandler<string> StartLoadClick;

        public MainGrupBox()
        {
            InitializeComponent();
           
        }

        public void StartSaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MP4|*.mp4|MPG4|*.mpg4|MPEG4|*.mpeg4";
            saveFileDialog.Title = "Save an Video File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                FileSavePatch = saveFileDialog.FileName;

                StartLoadClick?.Invoke(this, saveFileDialog.FileName);
                EndSaveFileDialog?.Invoke(this, EventArgs.Empty);

            }
        }

        public void ManualLoadStarted()
        {
            StartLoadClick?.Invoke(this, null);
        }

        public string FileSavePatch { get; private set; }

        public Image CurrentImage
        {
            get { return pictureBoxViev.Image; }
            set { pictureBoxViev.Image = value; }
        }

        public string CurrentListBoxText
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public int CurrentProgressBarPerceent
        {
            get { return progressBar.Value; }
            set { progressBar.Value = value; }
        }

        public string LoadSpead {
            get { return labelSpead.Text ;}
            set { labelSpead.Text = value; }
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopLoadClick?.Invoke(this, EventArgs.Empty);
        }
        
        private void btnLoad_Click(object sender, EventArgs e)
        {
            ManualLoadStarted();
        }

        
    }
}