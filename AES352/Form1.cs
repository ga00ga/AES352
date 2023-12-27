using System;
using System.Drawing;
using System.Windows.Forms;

namespace AES352
{
    public partial class Form1 : Form
    {
        private CommandParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new CommandParser(codeTextBox, displayArea);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This method is called when the form loads
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            // This method is called when the Run button is clicked
        }

        private void SyntaxButton_Click(object sender, EventArgs e)
        {
            // This method is called when the Syntax button is clicked
        }

        private void commandTextBox_TextChanged(object sender, EventArgs e)
        {
            // This method is for the the command box
        }

        private void displayArea_Click(object sender, EventArgs e)
        {
            // This method is for the display are picture Bos
        }
    }
}
