using System;
using System.Windows.Forms;

namespace Notepad
{
    public interface IMessageService {
        void ShowMassage(string massage);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
    }

    public class MessageService : IMessageService
    {
        public void ShowError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowMassage(string massage)
        {
            MessageBox.Show(massage, "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
