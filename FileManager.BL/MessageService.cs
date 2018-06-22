
using System.Windows.Forms;

namespace FileManager.BL
{
    public interface IMessageService
    {
        void ShowMessage(string text);

        void ShowWarning(string text);

        void ShowError(string text);
    }

    public class MessageService : IMessageService
    {
        public void ShowMessage(string text)
        {
            MessageBox.Show(text, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWarning(string text)
        {
            MessageBox.Show(text, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string text)
        {
            MessageBox.Show(text, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
