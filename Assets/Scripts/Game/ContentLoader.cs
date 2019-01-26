using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public class ContentLoader : MonoBehaviour
    {
        public TextAsset LoadTextFile(string file)
        {
            var text = Resources.Load<TextAsset>(file);
            return text; 
        }

        /// <summary>
        /// Loads an object from a json file. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public T LoadJsonObject<T>(string file)
        {
            var text = LoadTextFile(file);
            var textstr = text.text;
            var stripped = StripComments(textstr);
            var obj = JsonUtility.FromJson<T>(stripped);
            return obj; 
        }



        public string StripComments(string toStrip)
        {
            string result = "";
            var str = toStrip.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
                );  
            foreach(var s in str)
            {
                if (!string.IsNullOrWhiteSpace(s) && !(s[0] == '-' && s[1] == '-'))
                    result += s + Environment.NewLine; 
            }

            return result; 
        }
    }

