using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LZW
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = args[0];
            Dictionary<string, int> alphabet = new Dictionary<string, int>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (char c in text)
            {
                if (!alphabet.ContainsKey(c.ToString()))
                {
                    alphabet.Add(c.ToString(), alphabet.Count + 1);
                }
            }
            foreach (var item in alphabet.OrderBy(i => i.Key))
            {
                dictionary.Add(item.Key, item.Value);
            }
            string output = "";
            string word = text[0].ToString();
            for(int index = 1; index < text.Length; index++)
            {
                char nextChar = text[index];
                if (dictionary.ContainsKey(word + nextChar))
                {
                    word = word + nextChar;
                }
                else
                {
                    output = output + getIndex(dictionary,word);
                    dictionary.Add(word + nextChar,dictionary.Count+1);
                    word = nextChar.ToString();
                }
            }
            output = output + getIndex(dictionary, word);
            print(dictionary);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        static int getIndex(Dictionary<string, int> dictionary,string word)
        {
            int index = 1;
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                if (pair.Key.Equals(word))
                {
                    return index;
                }
                index++;
            }
            return 0;
        }

        static void print(Dictionary<string, int> dictionary)
        {
            Console.WriteLine("Index\tValue");
            foreach(KeyValuePair<string,int> pair in dictionary)
            {
                Console.WriteLine(pair.Value + "\t" + pair.Key);
            }
        }
    }
}
