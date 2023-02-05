using PTLab1.DBStructure;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;

namespace PTLab1
{
    public static class Sorts
    {
        /// <summary>Сортирует входной массив сортировкой выбором, оставляя начальный массив неизменным</summary>
        /// <returns>Возвращает отсортированный массив</returns>
        /// <param name="data">Входной массив данных</param>
        public static Info[] SelectSort(Info[] data)
        {
            Info[] result = new Info[data.Length];
            data.CopyTo(result, 0);

            DateTime start = DateTime.Now;

            for(int i = 0; i < result.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < result.Length; j++)
                    if (result[min] > result[j]) min = j;

                Info temp = result[min];
                result[min] = result[i];
                result[i] = temp;
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Сортировка выбором, {data.Length} элементов. {(end - start).TotalMilliseconds} мс");

            return result;
        }


        /// <summary>Сортирует входной массив сортировкой слиянием, оставляя начальный массив неизменным</summary>
        /// <returns>Возвращает отсортированный массив</returns>
        /// <param name="data">Входной массив данных</param>
        public static Info[] MergeSort(Info[] data)
        {
            Info[] result = new Info[data.Length];
            data.CopyTo(result, 0);

            DateTime start = DateTime.Now;

            Separation(result, 0, result.Length - 1);

            DateTime end = DateTime.Now;

            Console.WriteLine($"Сортировка слиянием, {data.Length} элементов. {(end - start).TotalMilliseconds} мс");

            return result;
        }


        /// <summary>Рекурсивно разделяет массив на два равныз подмассива, после чего сливает отсортированные части</summary>
        /// <param name="data">Входной массив данных</param>
        /// <param name="start">Начальный индекс разделения</param>
        /// <param name="end">Конечный индекс разделения</param>
        static void Separation(Info[] data, int start, int end)
        {
            if (end == start) return;

            int mid = (end + start) / 2;

            Separation(data, start, mid);
            Separation(data, mid + 1, end);

            Merge(data, start, mid, end);
        }

        /// <summary>Сливание отсортированных частей массива</summary>
        /// <param name="data">Входной массив данных</param>
        /// <param name="start">Начальный индекс разделения</param>
        /// <param name = "start" > Индекс границы между подмассивами</param>
        /// <param name="end">Конечный индекс разделения</param>
        static void Merge(Info[] data, int start, int mid, int end)
        {
            Info[] temp = new Info[end - start + 1];

            int i = start, j = mid + 1, count = 0;

            while(i <= mid && j <= end)
            {
                if(data[i] <= data[j])
                    temp[count++] = data[i++];
                else
                    temp[count++] = data[j++];
            }

            while(i <= mid) temp[count++] = data[i++];
            while(j <= end) temp[count++] = data[j++];

            for(int k = 0; k < end - start + 1; k++) 
            {
                data[start + k] = temp[k];
            }
        }


        /// <summary>Сортирует входной массив сортировкой кучей, оставляя начальный массив неизменным</summary>
        /// <returns>Возвращает отсортированный массив</returns>
        /// <param name="data">Входной массив данных</param>
        public static Info[] HeapSort(Info[] data)
        {
            Info[] result = new Info[data.Length];
            data.CopyTo(result, 0);

            DateTime start = DateTime.Now;

            for (int i = data.Length / 2 - 1; i >= 0; i--)
                DownHeap(data, i, data.Length);

            for(int i = data.Length - 1; i > 0; i--)
            {
                Info temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                DownHeap(data, 0, i);
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Сортировка кучей, {data.Length} элементов. {(end - start).TotalMilliseconds} мс");

            return result;
        }

        /// <summary>"Просеивание" элемента пирамиды</summary>
        /// <param name="data">Входной массив данных</param>
        /// <param name="start">Индекс просеиваемого элемента</param>
        /// <param name="end">Индекс окончания просеивания + 1</param>
        static void DownHeap(Info[] data, int start, int end)
        {
            Info now_elem = data[start];
            int child = 2 * start + 1;

            if (child < end - 1 && data[child] < data[child + 1]) child++;

            if(now_elem < data[child])
            {
                data[start] = data[child];
                data[child] = now_elem;

                if (2 * child + 1 < end)
                    DownHeap(data, child, end);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DataContext100())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };

            using (var db = new DataContext1000())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };

            using (var db = new DataContext10000())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };

            using (var db = new DataContext20000())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };

            using (var db = new DataContext40000())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };

            using (var db = new DataContext60000())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };

            using (var db = new DataContext80000())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };

            using (var db = new DataContext100000())
            {
                Info[] infos = db.Info.ToArray();
                Sorts.SelectSort(infos);
                Sorts.MergeSort(infos);
                Sorts.HeapSort(infos);
            };
        }
    }
}