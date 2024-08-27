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
        public static int SelectElement(string _message, XmlNode _dataIn, string _NameOfChildXML)  // функция отображает данные из XML и просит выбоать один из них
        {
            Console.WriteLine(_message);
            string tmpStr = "";
            int countOfNum = 0;
            int choise = 0;
            foreach (XmlElement _dataInChild in _dataIn) //подстановка цифр в выбор
            {
                if (_dataInChild.Name == _NameOfChildXML)
                {
                    countOfNum++;
                    Console.WriteLine($"{countOfNum.ToString()}.{_dataInChild.GetAttribute("name")}");
                    tmpStr += _dataInChild.GetAttribute("name") + ";";
                }
            }
            choise = select_value(countOfNum, 2) - 1;
            int tmp = 0;
            int tmp2 = 0;
            foreach (XmlElement _dataInChild in _dataIn) // ищим название элемента и ищем ее порядковый номер
            {
                if (_dataInChild.GetAttribute("name") == tmpStr.Split(";")[choise])
                {
                    return tmp2;
                    break;
                }
                tmp2++;
            }
            return tmp2;
        }
    }
}

