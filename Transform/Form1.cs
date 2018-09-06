using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transform
{
    public partial class TransformForm : Form
    {
        public TransformForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string originalText = textBoxInputOutput.Text;
            string fixedText = DoTransform(originalText);
            textBoxInputOutput.Text = fixedText;

        }



        protected string DoTransform(string incoming)
        {
            return ((String)incoming).Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "\'");
        }


        protected string UnDoTransform(string incoming)
        {
            return ((String)incoming).Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("\'", "&apos;");
        }

        protected string AddCData(string incoming)
        {
            return ("<![CDATA[" + System.Environment.NewLine + incoming  + System.Environment.NewLine + "]]>");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxInputOutput.Text))
            {
                Clipboard.Clear();    //Clear if any old value is there in Clipboard        
                Clipboard.SetText(textBoxInputOutput.Text); //Copy text to Clipboard
            }
        }

            

        private void button3_Click(object sender, EventArgs e)
        {
            string originalText = textBoxInputOutput.Text;
            string fixedText = UnDoTransform(originalText);
            textBoxInputOutput.Text = fixedText;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string originalText = textBoxInputOutput.Text;
            string fixedText = AddCData(originalText);
            textBoxInputOutput.Text = fixedText;
        }
    }
}
