using System;
using System.Diagnostics;
using System.Windows.Forms;
using FileManager.BL;
using ParserCore.BL;
using ParserCore.BL.coursehunters;


namespace parserVideo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mForm = new MainForm();
           
            var parser = new ParserWorker<ParsData[]>(new CourseHunterParser());
            var messageService = new MessageService();
            var mFileManager = new MainFileManager();

            new CurseHunterPresenter(
                mForm,
                mFileManager,
                messageService,
                parser
            );

            Application.Run(mForm);
        }
    }
}