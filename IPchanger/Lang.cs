using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPchanger
{
    public class Lang
    {
        /// <summary>
        /// PUBLIC DECLARATIONS
        /// </summary>
        public Dictionary<string, string> Pol;
        public Dictionary<string, string> Ger;
        public Dictionary<string, string> Esp;
        public Dictionary<string, string> Fra;
        public Dictionary<string, string> Rus;
        public string SelectedLang;

        /**
         * \brief           Constructor function for translation object
         */
        public Lang()
        {
            ReadSelect();   /* Read selection for using language in application */

            /* All dictionaries have TKey as English word for searching translated one */
            Pol = new Dictionary<string, string>();
            Ger = new Dictionary<string, string>();
            Esp = new Dictionary<string, string>();
            Fra = new Dictionary<string, string>();
            Rus = new Dictionary<string, string>();

            ReadDict("Pol");
            ReadDict("Ger");
            ReadDict("Esp");
            ReadDict("Fra");
            ReadDict("Rus");
        }

        /**
         * \brief           Reading dictionary vocabulary from selected file
         * \param[1]        String name/type of dictionary for reading
         */
        private void ReadDict(string dict)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string line = "";
            string[] txt;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(dict + ".txt");

                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    /* All dictionaries *.txt files have simple structure where words TKey and Translated
                     * are separated with ';' symbol. All translations are  separated with NewLines. */
                    txt = line.Split(';');
                    if (dict == "Pol") Pol.Add(txt[0], txt[1]);
                    else if (dict == "Ger") Ger.Add(txt[0], txt[1]);
                    else if (dict == "Esp") Esp.Add(txt[0], txt[1]);
                    else if (dict == "Fra") Fra.Add(txt[0], txt[1]);
                    else if (dict == "Rus") Rus.Add(txt[0], txt[1]);

                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception ex) { }
        }

        /**
         * \brief           Translate function in proper Dictionary
         *                  Depends on public variable: SelectedLang
         * \param[1]        String word to translate from English (TKey in dictionaries)
         * \return          String type translated word/sentence
         */
        public string transl(string word)
        {
            string output = string.Empty;
            switch(SelectedLang)            
            {
                case "Pol":
                    output = Pol[word];
                    break;
                case "Ger":
                    output = Ger[word];
                    break;
                case "Esp":
                    output = Esp[word];
                    break;
                case "Fra":
                    output = Fra[word];
                    break;
                case "Rus":
                    output = Rus[word];
                    break;
                case "Eng":
                    output = word;
                    break;
                default:
                    output = word; /* When selected new Dictionary (not implemented), also translate to English */
                    break;
            }
            return output;
        }

        /**
         * \brief           Read settings from the file
         */
        private void ReadSelect()
        {
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("setting.txt");
                SelectedLang = sr.ReadLine();
                sr.Close();
            }
            catch (Exception ex) { }
        }

        /**
         * \brief           Write settings to the file
         */
        public void WriteSelect(string sel)
        {
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamWriter sw = new StreamWriter("setting.txt");
                sw.WriteLine(sel);
                SelectedLang = sel;
                sw.Close();
            }
            catch (Exception ex) { }
        }

    }
}
