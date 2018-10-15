using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace III_upr3
{
    public partial class Form1 : Form
    {

        private string currentTextContent;
        Trie wordTree = new Trie();
        ParagraphParser myParser;

        public Form1()
        {
            InitializeComponent();

            parseTextToTrie();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textToSearch = textBox1.Text;
            Benchmarker myTester = new Benchmarker(textBox4);
            myTester.StartBenchmark();
            int countOccurences = wordTree.GetSyllableCount(textToSearch);
            myTester.EndBenchmark();
            textBox3.Text = countOccurences.ToString();
        }


        private void parseTextToTrie()
        {
            currentTextContent = richTextBox1.Text; // Keep the state of the text box in sync with the private store.
            myParser = new ParagraphParser(currentTextContent);
            List<string> currentCollection = myParser.getParsedParagraph();
            wordTree.addCollectionToTrie(currentCollection);

            
        }
    }
}
