using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GenDomainXML
{
    internal class DataFunc
    {
        public static int select_value(int _maxlength, int _attempt)
        {
            int n = 0;
            string tmp = "";
            Console.WriteLine($"Введите число от 1 до {_maxlength}:");
            for (int i = 0; i <= _attempt; i++)
            {
                tmp = Console.ReadLine();
                if (int.TryParse(tmp, out n))
                {
                    if ((1 <= int.Parse(tmp)) && (int.Parse(tmp) <= _maxlength))
                        return int.Parse(tmp);
                        break;
                }
                else
                {
                    Console.WriteLine($"Необходимо ввести число от 1 до + {_maxlength} + оставшееся количество попыток {_attempt - i}");
                }
            }
            return -1;
        }
        public static int dataToScrean(string _message, XmlElement _dataIn)
        {
            Console.WriteLine(_message);
            int countOfNum = 0;
            foreach (XmlElement _dataInChild in _dataIn)
            {
                if (_dataInChild.Name == "dp:domain")
                {
                    countOfNum++;
                    Console.WriteLine($"{countOfNum.ToString()}. {_dataInChild.GetAttribute("name")}");
                }
            }
            return select_value(countOfNum, 2);
        }



    }
}

