using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{

    public interface IMainForm
    {
        string FilePath
        {
            get;
        }
        string Content
        {
            get; set;
        }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            butOpenFile.Click += new EventHandler(ButOpenFile_Click);
            butSaveFile.Click += new EventHandler(ButSaveFile_Click);
            fldContent.TextChanged += new EventHandler(FldContent_TextChanged);
            butSelectFile.Click += new EventHandler(ButSelectFile_Click);
            numFont.ValueChanged += new EventHandler(NumFont_ValueChanged);
        }

        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numFont.Value);
        }

        private void ButSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files|*.txt|All files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;

                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        #region Проброс событий 
        private void FldContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }
        private void ButSaveFile_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }
        private void ButOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }
        #endregion

        #region IMainForm Реализация
        public string Content
        {
            get
            {
                return fldContent.Text;
            }

            set
            {
                fldContent.Text = value;
            }
        }
        public string FilePath
        {
            get
            {
                return fldFilePath.Text;
            }
        }

        public event EventHandler ContentChanged;
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;

        public void SetSymbolCount(int count)
        {
            lblSymbolCount.Text = count.ToString();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
