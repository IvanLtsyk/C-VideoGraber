using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileManager.BL;
using ParserCore.BL;
using parserVideo.Primitives;

namespace parserVideo
{
    public class CurseHunterPresenter
    {
        private string _selectedFolder = null;
        private readonly IMainForm _viev;
        private readonly IFileManager _fileManager;
        private readonly IMessageService _mainMessageService;
        private readonly IParserWorker<ParsData[]> _parserWorker;

        public CurseHunterPresenter(
            IMainForm viev,
            IFileManager fileManager,
            IMessageService service,
            IParserWorker<ParsData[]> parserWorker
        )
        {
            _viev = viev;
            _fileManager = fileManager;
            _mainMessageService = service;
            _parserWorker = parserWorker;


            _parserWorker.OnComplitted += _parserWorker_OnComplitted;
            _parserWorker.OnNewData += _parserWorker_OnNewData;

            _viev.StartParsClick += _viev_StartParsClick;
            _viev.StopParsClick += _viev_StopParsClick;
            _viev.ChangeCurentUrl += _viev_ChangeCurentUrl;
            _viev.ChangeCurentFolder += _viev_ChangeCurentFolder;
            _viev.SaveAll += _viev_SaveAll;
        }

        public List<MainGrupBox> MainGrupBoxList { get; set; }

        private void _viev_SaveAll(object sender, string e)
        {
            _viev_ChangeCurentFolder(sender, e);
            foreach (var grupBox in MainGrupBoxList)
            {
                grupBox.ManualLoadStarted();
            }
        }

        private void _viev_ChangeCurentFolder(object sender, string e)
        {
            Debug.WriteLine(e);
            _selectedFolder = e;
        }

        private void _parserWorker_OnComplitted(object obj)
        {
            Debug.WriteLine("Pars OnComplitted");
        }

        private void _viev_ChangeCurentUrl(object sender, string url)
        {
            _parserWorker.ParsContentUrl = url;
        }

        private void _viev_StopParsClick(object sender, EventArgs e)
        {
            _parserWorker.Abort();
        }

        private void _viev_StartParsClick(object sender, EventArgs e)
        {
            _parserWorker.Start();
        }

        private Image getImagePreload(string url)
        {
            var newUrl = "https://coursehunters.net/" + url;

            try
            {
                byte[] data = _fileManager.DownloadDataStream(newUrl);
                var image = _fileManager.ByteArrayToImage(data);
                return image;
            }
            catch (Exception exception)
            {
                _mainMessageService.ShowError(exception.Message);
                return null;
            }
        }

        private void _parserWorker_OnNewData(object arg1, ParsData[] arg2)
        {
            var mgb = new List<MainGrupBox>();
            int tempCount = 0;
            foreach (var parsData in arg2)
            {
                var item = new MainGrupBox();

                item.Location = new Point(12, (item.Height + 5) * tempCount);
                item.CurrentImage = getImagePreload(parsData.ImageUrl);

                item.Tag = parsData;
                item.CurrentListBoxText = $"imageUrl:{parsData.ImageUrl}\n\nvideoUrl:{parsData.WideoUrl}";
                item.StartLoadClick += Item_StartLoadClick;

                mgb.Add(item);

                Debug.WriteLine($"{parsData.ImageUrl}");
                Debug.WriteLine($"{parsData.WideoUrl}");
                Debug.WriteLine($"{parsData.FileName}");


                _viev.SetPanel(item);
                tempCount += 1;
            }

            // mgb[0].ManualLoadStarted();
            MainGrupBoxList = mgb;
        }

        private void Item_StartLoadClick(object sender, string filePatch)
        {
            MainGrupBox item = (MainGrupBox)sender;
            ParsData data = (ParsData)item.Tag;
            Debug.WriteLine(data.WideoUrl);

            var fileName = Slug.OnlySeparatorFfriendly(data.FileName);
            string currentUrl = getCurrentUrl(filePatch, fileName, data.WideoUrl);

            Debug.WriteLine($"filePatch{filePatch}");
            Debug.WriteLine($"selectedFolder{_selectedFolder}");

            Debug.WriteLine($"currentUrl{currentUrl}");


            if (currentUrl == "")
            {
                item.StartSaveDialog();
                return;
            }

            var mFilleManager = new MainFileManager();

            var a = new EventHandler((s, e) =>
            {
                item.CurrentProgressBarPerceent = mFilleManager.Progres;
                item.LoadSpead = mFilleManager.LoadSpead;
            });

            mFilleManager.ChangedPercent += a;
            mFilleManager.DownloadEnd += (o, e) => mFilleManager.ChangedPercent -= a;

            try
            {
                mFilleManager.DownloadFile(data.WideoUrl, currentUrl);
            }
            catch (Exception exception)
            {
                _mainMessageService.ShowError(exception.StackTrace);
            }
        }

        private string getCurrentUrl(string filePatch, string fileName, string wideoUrl)
        {
            if (_selectedFolder == null && filePatch == null)
            {
                return "";
            }

            if (_selectedFolder != null)
            {
                //              String[] slplitList = wideoUrl.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
                //                return ($"{_selectedFolder}/{fileName}{Path.GetExtension(wideoUrl)}");
                return Path.Combine(_selectedFolder, fileName + Path.GetExtension(wideoUrl));
            }

            return filePatch;
        }
    }
}