using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace FileManager.BL
{
    public interface IFileManager
    {
        event EventHandler ChangedPercent;
        event EventHandler DownloadEnd;

        void DownloadFile(string urlAddress, string filePatch);
        int Progres { get; }
        string LoadSpead { get; }
        byte[] DownloadDataStream(string Url);
        Image ByteArrayToImage(byte[] byteArrayIn);
    }

    public class MainFileManager : IFileManager
    {
        private readonly IMessageService _messageService = new MessageService();

        public event EventHandler ChangedPercent;
        public event EventHandler DownloadEnd;


        public int Progres { get; private set; }

        public string LoadSpead { get; private set; }

        WebClient webClient;

        Stopwatch sw = new Stopwatch();

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);

                return returnImage;
            }
            catch (Exception e)
            {
                _messageService.ShowError(e.StackTrace);
                throw e;
            }
            finally
            {
                ms.Close();
            }
        }

        public void DownloadFile(string urlAddress, string filePatch)
        {
            if (urlAddress == null)
            {
                _messageService.ShowWarning("Відсутній урл зображення");
                return;
            }

            if (filePatch == null)
            {
                _messageService.ShowError("Не вибраний шлях збереження");
                return;
            }

            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                    ? new Uri(urlAddress)
                    : new Uri("https://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();


                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, filePatch);
                }
                catch (Exception ex)
                {
                    _messageService.ShowError("Не вибраний шлях збереження");
                    sw.Stop();
                    throw ex;
                }
               
            }
        }

        private ushort total = 0;

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            total += 1;
            // Calculate download speed and output it to labelSpeed.
            /*labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));*/

            Progres = e.ProgressPercentage;

            LoadSpead = string.Format("{0}", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            
                ChangedPercent?.Invoke(this, EventArgs.Empty);
            
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();

            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
            }
            else
            {
                Debug.WriteLine("Download completed!");
                DownloadEnd?.Invoke(this, EventArgs.Empty);
            }
        }

        public byte[] DownloadDataStream(string Url)
        {
            byte[] downloadedData = new byte[0];
            Stream stream = null;
            MemoryStream memStream = new MemoryStream();
            try
            {
                WebRequest req = WebRequest.Create(Url);
                WebResponse response = req.GetResponse();
                stream = response.GetResponseStream();

                byte[] buffer = new byte[1024];
                int dataLength = (int) response.ContentLength;


                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    
                    if (bytesRead == 0 )
                    {
                        //Finished downloading
                     
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                    }
                }

                return memStream.ToArray();
            }
            catch (Exception err)
            {
                _messageService.ShowError("Не вибраний шлях до файлу");
                throw err;
            }
            finally
            {
                stream.Close();
                memStream.Close();
            }

            //            return stream;
        }
    }
}