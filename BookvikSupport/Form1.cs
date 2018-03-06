using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookvikSupport
{
    public partial class Form1 : Form
    {
        private bool _isPageAdd = false;
        public List<PageContent> PageContents = new List<PageContent>();
       
        public BindingModel.Book Book = new BindingModel.Book();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            }

        private void pageContent1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_isPageAdd)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                _isPageAdd = true;
                if (GetNotes(textBox1.Text) <= 0)
                {
                    int count = Convert.ToInt32(textBox2.Text);
                    groupBox2.Text = textBox1.Text;

                    if (count > tableLayoutPanel1.RowCount)
                        for (int i = tableLayoutPanel1.RowCount; i < count; i++)
                        {
                            tableLayoutPanel1.RowCount++;
                            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62));
                        }

                    for (int i = 1; i <= count; i++)
                    {
                        var page = new PageContent()
                        {
                            NamePage = "Сторінка " + i,
                            PlaceInGroup = i
                        };
                        PageContents.Add(page);
                        tableLayoutPanel1.Controls.Add(page);
                    }

                }
                else
                {
                    button2.Visible = false;
                    button4.Visible = true;
                    button4.Enabled = true;
                }
               
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private int GetNotes(string name)
        {
            DataBaseConnector db = new DataBaseConnector();
           var pages = db.GetAllPage(name);
            groupBox2.Text = textBox1.Text;
            int count = pages.Count;
            if (count > tableLayoutPanel1.RowCount)
                for (int i = tableLayoutPanel1.RowCount; i < count; i++)
                {
                    tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62));
                }

            for (int i = 0; i < pages.Count; i++)
            {
                var page = new PageContent()
                {
                    NamePage = "Сторінка " + (i+1),
                    PlaceInGroup = i+1,
                    Name = pages[i].Name,
                    Type = pages[i].Type,
                    Model = pages[i].Model,
                    Number = pages[i].Number,
                    YoutubeLink1 = pages[i].YoutubeLink1,
                    YoutubeLink2 = pages[i].YoutubeLink2,
                    GameLink2 = pages[i].GameLink2,
                    GameLink1 = pages[i].GameLink1,
                    Id = pages[i].BookId
                };
                PageContents.Add(page);
                tableLayoutPanel1.Controls.Add(page);
            }

          return pages.Count;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CleareAll();
        }

        private void CleareAll()
        {
            _isPageAdd = false;
            tableLayoutPanel1.Controls.Clear();
            groupBox2.Text = "/";
            textBox1.Text = "";
            textBox2.Text = "";
            button3.Enabled = false;
            button2.Visible = true;
            button4.Visible = false;
            button4.Enabled = true;
            button2.Enabled = false;
            PageContents.Clear();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            InsertElements();            
        }

        private void InsertElements()
        {
            DataBaseConnector db = new DataBaseConnector();
            Book.NameBook = textBox1.Text;
            db.InsertNewBook(Book);
      
            foreach (var p in PageContents)
            {
                BindingModel.Page page = new BindingModel.Page(p.PlaceInGroup,p.Number,p.Name,p.Type,p.Model,p.YoutubeLink1,p.YoutubeLink2,p.GameLink1,p.GameLink2,Book.Id);
                db.InsertPagesInBook(page);
            }
            CleareAll();
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBaseConnector db = new DataBaseConnector();
           

            foreach (var p in PageContents)
            {
                BindingModel.Page page = new BindingModel.Page(p.PlaceInGroup, p.Number, p.Name, p.Type, p.Model, p.YoutubeLink1, p.YoutubeLink2, p.GameLink1, p.GameLink2,p.Id);
                db.ChangeData(page);
            }
            CleareAll();
           // button2.Enabled = true;
        }
    }
}
