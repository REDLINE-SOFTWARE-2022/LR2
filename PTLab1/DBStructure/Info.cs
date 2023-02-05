using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PTLab1.DBStructure
{
    /// <summary>Класс с данными об абитуриенте</summary>
    public class Info
    {
        /// <value>Поле для взаимодействия с базой данных</value>
        public int? InfoId { get; set; }
        /// <value>Имя абитууриента</value>
        public string? Name { get; set; }
        /// <value>Факультет абитуриента</value>
        public string? Faculty { get; set; }
        /// <value>Специальность абитуриента</value>
        public string? Speciality { get; set; }
        /// <value>Сумма баллов абитуриента</value>
        public int? Score { get; set; }

        /// <summary>Перегрузка оператора сравнения меньше</summary>
        /// <returns>Возвращает true, если левый меньше, false - иначе</returns>
        /// <param name="left">Левый элемент</param>
        /// <param name="right">Правый элемент</param>
        public static bool operator<(Info left, Info right)
        {
            if (left.Score == right.Score)
            {
                if (string.Compare(left.Name, right.Name) == 0)
                {
                    if (string.Compare(left.Faculty, right.Faculty) == 0)
                    {
                        if (string.Compare(left.Speciality, right.Speciality) == 0)
                            return false;

                        if (string.Compare(left.Speciality, right.Speciality) > 0)
                            return false;
                        return true;
                    }
                    else if (string.Compare(left.Faculty, right.Faculty) > 0)
                        return false;
                    return true;
                }
                else if (string.Compare(left.Name, right.Name) > 0)
                    return false;
                return true;
            }
            else if (left.Score > right.Score)
                return false;

            return true;
        }

        /// <summary>Перегрузка оператора сравнения больше</summary>
        /// <returns>Возвращает true, если левый больше, false - иначе</returns>
        /// <param name="left">Левый элемент</param>
        /// <param name="right">Правый элемент</param>
        public static bool operator >(Info left, Info right)
        {
            if (left.Score == right.Score)
            {
                if (string.Compare(left.Name, right.Name) == 0)
                {
                    if (string.Compare(left.Faculty, right.Faculty) == 0)
                    {
                        if (string.Compare(left.Speciality, right.Speciality) == 0)
                            return false;

                        if (string.Compare(left.Speciality, right.Speciality) < 0)
                            return false;
                        return true;
                    }
                    else if (string.Compare(left.Faculty, right.Faculty) < 0)
                        return false;
                    return true;
                }
                else if (string.Compare(left.Name, right.Name) < 0)
                    return false;
                return true;
            }
            else if (left.Score < right.Score)
                return false;

            return true;
        }

        /// <summary>Перегрузка оператора сравнения меньше или равно</summary>
        /// <returns>Возвращает true, если левый меньше или равен правому, false - иначе</returns>
        /// <param name="left">Левый элемент</param>
        /// <param name="right">Правый элемент</param>
        public static bool operator <=(Info left, Info right)
        {
            if (left.Score == right.Score)
            {
                if (string.Compare(left.Name, right.Name) == 0)
                {
                    if (string.Compare(left.Faculty, right.Faculty) == 0)
                    {
                        if (string.Compare(left.Speciality, right.Speciality) == 0)
                            return true;

                        if (string.Compare(left.Speciality, right.Speciality) > 0)
                            return false;
                        return true;
                    }
                    else if (string.Compare(left.Faculty, right.Faculty) > 0)
                        return false;
                    return true;
                }
                else if (string.Compare(left.Name, right.Name) > 0)
                    return false;
                return true;
            }
            else if (left.Score > right.Score)
                return false;

            return true;
        }

        /// <summary>Перегрузка оператора сравнения больше или равно</summary>
        /// <returns>Возвращает true, если левый больше или равен правому, false - иначе</returns>
        /// <param name="left">Левый элемент</param>
        /// <param name="right">Правый элемент</param>
        public static bool operator >=(Info left, Info right)
        {
            if (left.Score == right.Score)
            {
                if (string.Compare(left.Name, right.Name) == 0)
                {
                    if (string.Compare(left.Faculty, right.Faculty) == 0)
                    {
                        if (string.Compare(left.Speciality, right.Speciality) == 0)
                            return true;

                        if (string.Compare(left.Speciality, right.Speciality) < 0)
                            return false;
                        return true;
                    }
                    else if (string.Compare(left.Faculty, right.Faculty) < 0)
                        return false;
                    return true;
                }
                else if (string.Compare(left.Name, right.Name) < 0)
                    return false;
                return true;
            }
            else if (left.Score < right.Score)
                return false;

            return true;
        }
    }
}
