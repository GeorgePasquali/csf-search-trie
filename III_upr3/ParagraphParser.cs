using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace III_upr3
{
    class ParagraphParser
    {

        List<string> parsedParagraph;

        public ParagraphParser(string inputParagraph)
        {

            parsedParagraph = ParagraphParse(inputParagraph);

        }

        public static List<string> ParagraphParse(string paragraph)
        {

            List<string> outputParagraph = new List<string>();
            StringBuilder wordBuffer = new StringBuilder();

            foreach (char singleChar in paragraph)
            {
                if (
                    char.IsWhiteSpace(singleChar) ||
                    char.IsPunctuation(singleChar) ||
                    singleChar == '`'

                )
                {
                    if ((wordBuffer.Length > 0) && wordBuffer.Length > 2)
                    {
                        outputParagraph.Add(wordBuffer.ToString());
                    }

                    wordBuffer.Clear();
                }
                else
                {
                    wordBuffer.Append(singleChar);
                }


            }

            if ((wordBuffer.Length > 0) && wordBuffer.Length > 2)
            {
                outputParagraph.Add(wordBuffer.ToString());
            }

            return outputParagraph;
        }

        public List<string> getParsedParagraph()
        {
            return parsedParagraph;
        }

        public int getParagraphLength()
        {
            return parsedParagraph.Count();
        }

        public void printCurrentParagraphToTextBox(TextBox box)
        {
            foreach (string number in parsedParagraph)
            {
                box.AppendText(number + "\n");
            }
        }

    }
}
