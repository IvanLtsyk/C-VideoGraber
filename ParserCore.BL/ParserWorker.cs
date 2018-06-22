using System;
using System.Windows.Forms;
using AngleSharp.Parser.Html;

namespace ParserCore.BL
{
    public interface IParserWorker<T>
    {
        void Start();
        void Abort();
        event Action<object, T> OnNewData;
        event Action<object> OnComplitted;
        string ParsContentUrl { get; set; }
    }

    public class ParserWorker<T> : IParserWorker<T> where T : class
    {
        private HTMLLoader _loader;

        public string ParsContentUrl
        {
            get { return _loader.ParseContentUrl; }
            set
            {
                if (_loader != null)
                {
                    _loader.ParseContentUrl = value;
                }
            }
        }


        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
            ParsContentUrl = "https://coursehunters.net/course/level-2-react";

            _loader = new HTMLLoader();
            _loader.ParseContentUrl = ParsContentUrl;
        }


        # region Properties 

        public IParser<T> Parser { get; set; }

        public bool IsActiveFlag { get; set; }

        # endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnComplitted;


        public void Start()
        {
            IsActiveFlag = true;
            Worker();
        }

        public void Abort()
        {
            IsActiveFlag = false;
        }

        private async void Worker()
        {
            if (ParsContentUrl == null)
            {
                MessageBox.Show("There is no url for robbery!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!IsActiveFlag)
            {
                OnComplitted?.Invoke(this);
                return;
            }

            var source = await _loader.GetSourceByPageId();
            var domParser = new HtmlParser();
            var document = await domParser.ParseAsync(source);

            var result = Parser.Parse(document);

            OnNewData?.Invoke(this, result);

            OnComplitted?.Invoke(this);
            IsActiveFlag = false;
        }
    }
}