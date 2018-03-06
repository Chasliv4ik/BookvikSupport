using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookvikSupport
{
    public partial class PageContent : UserControl
    {
        private string _namePage;
        
        private string _number;
        private string _name;
        private string _type;
        private string _model = null;
        private string _youtubeLink1=null;
        private string _youtubeLink2=null;
        private string _gameLink1=null;
        private string _gameLink2=null;

        public int PlaceInGroup;
        private int _id;

        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                numericUpDown1.Value = Convert.ToDecimal(_number);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {   
                
                _name = value;
                if(!_name.Contains("PageContent"))
                textBox1.Text = _name;
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                var b = new object();
                foreach (var it in comboBox1.Items)
                {
                    if (it.ToString() == _type)
                    {
                        b = it;
                        break;
                    }
                }
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(b);
            }
        }
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                textBox6.Text = _model;
            }
        }
        public int Id
        {

            get { return _id; }
            set { _id = value; }

        }
        public string YoutubeLink1
        {
            get { return _youtubeLink1; }
            set
            {
                _youtubeLink1 = value;
                textBox2.Text = _youtubeLink1;
            }
        }
        public string YoutubeLink2
        {
            get { return _youtubeLink2; }
            set
            {
                _youtubeLink2 = value;
                textBox3.Text = _youtubeLink2;
            }
        }

        public string GameLink1
        {
            get { return _gameLink1; }
            set
            {
                _gameLink1 = value;
                textBox5.Text = _gameLink1;
            }
        }

        public string GameLink2
        {
            get { return _gameLink2; }
            set
            {
                _gameLink2 = value;
                textBox4.Text = _gameLink2;
            }
        }


        public string NamePage
        {
            get { return _namePage; }
            set
            {
                _namePage = value;
                SetNamePage();
            }
        }

        public void SetNamePage()
        {
            groupBox1.Text = _namePage;
        }

        public PageContent()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text!=String.Empty)
            _youtubeLink1 = textBox2.Text;
            else
            {
                _youtubeLink1 = null;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _number = numericUpDown1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _name = textBox1.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {   if(textBox6.Text!=String.Empty)
            _model = textBox6.Text;
            else
            {
                _model = null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _type = comboBox1.Items[comboBox1.SelectedIndex].ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != String.Empty)
                _youtubeLink2 = textBox3.Text;
            else
                _youtubeLink2 = null;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.Text!=String.Empty)
            _gameLink1 = textBox5.Text;
            else
            {
                _gameLink1 = null;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text!=String.Empty)
            _gameLink2 = textBox4.Text;
            else
            {
                _gameLink2 = null;
            }
        }
    }
}
