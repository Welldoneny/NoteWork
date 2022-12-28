using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FlatDesign
{
    public partial class NoteWork : Form
    {
        public NoteWork()
        {
            InitializeComponent();
            isNotebook= true;
            textBoxNotebook.Show();
            textBoxWord.Hide();
            textBoxNoteWork.Hide();
            textBoxMarkDown.Hide();
        }

        bool isNotebook = true;
        bool isWord = false;
        bool isNote = false;
        bool isMarkDown = false;
        string PATHNOTE = "C:\\Users\\Admin\\Desktop\\NoteWork";

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string PATH = string.Empty;
            if (!isNote)
            {
                PATH = textBoxPath.Text;
                PATH = PATH.Remove(PATH.Length - 4);
            }

                     
            if (isNotebook)
            {
                string note = textBoxNotebook.Text;                
                File.WriteAllText(PATH + ".txt", " " + note);
            }

            if (isWord)
            {
                string note = textBoxWord.Text;
                File.WriteAllText(PATH + ".doc", " " + note);
            }

            if (isNote)
            {
                string note = textBoxNoteWork.Text;
                if (File.Exists(PATHNOTE + ".txt"))
                {

                    File.AppendAllText(PATHNOTE + ".txt", " " + note);
                }
                else
                {
                    File.WriteAllText(PATHNOTE + ".txt", note);
                }
            }

            if (isMarkDown)
            {
                string mark = textBoxMarkDown.Text;
                File.WriteAllText(PATH + ".md", " " + mark);
            }

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            //string PATH = textBoxPath.Text;
            //StreamReader fileStream = File.OpenText(PATH);
            //textBoxNotebook.Text = fileStream.ToString();
            Form form = new Form2();
            form.Show();
        }

        private void BtnNotepad_Click(object sender, EventArgs e)
        {
            isNotebook = true;
            isWord= false;
            isNote = false;
            isMarkDown = false;
            labelTypeValue.Text = "Notebook";
            textBoxPath.Text = "C:\\\\Users\\\\Admin\\\\Desktop\\\\somenew.txt";
            textBoxNotebook.Show();
            textBoxWord.Hide();
            textBoxNoteWork.Hide();
            textBoxMarkDown.Hide();
        }

        private void BtnWord_Click(object sender, EventArgs e)
        {            
            isNotebook= false;
            isWord = true;
            isNote= false;
            isMarkDown = false;
            labelTypeValue.Text = "Word";
            textBoxPath.Text = "C:\\\\Users\\\\Admin\\\\Desktop\\\\somenew.doc";
            textBoxNotebook.Hide();
            textBoxWord.Show();
            textBoxNoteWork.Hide();
            textBoxMarkDown.Hide();
        }

        private void BtnNoteWork_Click(object sender, EventArgs e)
        {
            isNote = true;
            isWord= false;
            isNotebook= false;
            isMarkDown = false;
            labelTypeValue.Text = "Note Work";
            textBoxPath.Text = string.Empty;
            textBoxNotebook.Hide();
            textBoxWord.Hide();
            textBoxNoteWork.Show();
            textBoxMarkDown.Hide();
        }

        private void BtnMarkDown_Click(object sender, EventArgs e)
        {
            isNote = false;
            isWord = false;
            isNotebook = false;
            isMarkDown = true;
            labelTypeValue.Text = "Mark Down";
            textBoxPath.Text = "C:\\\\Users\\\\Admin\\\\Desktop\\\\somenew.md";
            textBoxNotebook.Hide();
            textBoxWord.Hide();
            textBoxNoteWork.Hide();
            textBoxMarkDown.Show();
        }

        private void BtnSaveTo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранить в...";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CheckPathExists = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                textBoxPath.Text = fileName;

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string text = reader.ReadLine();
                    reader.Close();
                    if (isNotebook)
                    {
                        textBoxNotebook.Text = text;
                    }
                    if (isWord)
                    {
                        textBoxWord.Text = text;
                    }
                    if (isMarkDown)
                    {
                        textBoxMarkDown.Text = text;
                    }
                }
            }

        }

        private void NoteWork_Load(object sender, EventArgs e)
        {
            if (File.Exists(PATHNOTE + ".txt"))
            {
                using (StreamReader reader = new StreamReader(PATHNOTE + ".txt"))
                {
                    string text = reader.ReadLine();
                    reader.Close();
                    textBoxNoteWork.Text = text;
                }
            }
        }
    }
}
