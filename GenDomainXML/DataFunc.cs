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
        public static int select_value(int _maxlength, int _attempt) // функция для выбора из заданного количества параметров 
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
                    {
                        return int.Parse(tmp);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Необходимо ввести число от 1 до + {_maxlength}, оставшееся количество попыток {_attempt - i}");
                    }
                }
                else
                {
                    Console.WriteLine($"Необходимо ввести число от 1 до + {_maxlength}, оставшееся количество попыток {_attempt - i}");
                }
            }
            return -1;
        }
        public static string SelectElement(string _message, XmlElement _dataIn, string _NameOfChildXML) // функция отображает данные из XML и просит выбоать один из них
        {
            Console.WriteLine(_message);
            int countOfNum = 0;
            foreach (XmlElement _dataInChild in _dataIn)
            {
                if (_dataInChild.Name == _NameOfChildXML)
                {
                    countOfNum++;
                    Console.WriteLine($"{countOfNum.ToString()}.{_dataInChild.GetAttribute("name")}");
                }
            }
            int tmp = select_value(countOfNum, 2)-1; //колхоз
            int tmp2 = 0;
            Console.WriteLine("tmp="+tmp);
            foreach (XmlElement _dataInChild in _dataIn)
            {
                if (_dataInChild.Name == _NameOfChildXML && tmp2 == tmp)
                {
                    return _dataInChild.GetAttribute("name");
                    break;
                }
                else if (_dataInChild.Name == _NameOfChildXML)
                {
                    tmp2++;
                }
            }
            return "";
        }

        public static string GetNameById(string _message, XmlElement _dataIn, string _NameOfChildXML) // функция отображает данные из XML и просит выбоать один из них
        {
            /* Console.WriteLine(_message);
             int countOfNum = 0;
             foreach (XmlElement _dataInChild in _dataIn)
             {
                 if (_dataInChild.Name == _NameOfChildXML)
                 {
                     countOfNum++;
                     Console.WriteLine($"{countOfNum.ToString()}.{_dataInChild.GetAttribute("name")}");
                 }
             }
             return select_value(countOfNum, 2) - 1; // -1 чтобы "подогнать" выбор к id xml*/
            return "";
        }







    }
}

