using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using laba5;

namespace laba_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        List<string> list = new List<string>();
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "текстовые файлы|*.txt";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                //Чтение файла в виде строки
                string text = File.ReadAllText(fd.FileName);
                //Разделительные символы для чтения из файла
                char[] separators =
                new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] textArray = text.Split(separators);
                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки
                    string str = strTemp.Trim();
                    //Добавление строки в список, если строка не содержится
                    if (!list.Contains(str)) list.Add(str);
                }

                t.Stop();
                this.textBox1.Text = t.Elapsed.ToString();
                this.textBox2.Text = list.Count.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Слово для поиска
            string word = this.textBox1.Text.Trim();

            //Если слово для поиска не пусто
            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {
                //Слово для поиска в верхнем регистре
                string wordUpper = word.ToUpper();
                //Временные результаты поиска
                List<string> tempList = new List<string>();
                Stopwatch t = new Stopwatch();
                t.Start();
                foreach (string str in list)
                {
                    if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }
                t.Stop();
                this.textBox5.Text = t.Elapsed.ToString();
                this.listBox1.BeginUpdate();
                //Очистка списка
                this.listBox1.Items.Clear();
                //Вывод результатов поиска
                foreach (string str in tempList)
                {
                    this.listBox1.Items.Add(str);
                }
                this.listBox1.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }

        public static List<ParallelSearchResult> ArrayThreadTask(object
            paramObj)
        {
            ParallelSearchThreadParam param =
           (ParallelSearchThreadParam)paramObj;
            //Слово для поиска в верхнем регистре
            string wordUpper = param.wordPattern.Trim().ToUpper();
            //Результаты поиска в одном потоке
            List<ParallelSearchResult> Result = new
           List<ParallelSearchResult>();
            //Перебор всех слов во временном списке данного потока
            foreach (string str in param.tempList)
            {
                //Вычисление расстояния Дамерау-Левенштейна
                int dist = Levishtain.Distance(str.ToUpper(), wordUpper);
                //Если расстояние меньше порогового, то слово добавляется в
            if (dist <= param.maxDist)
                {
                    ParallelSearchResult temp = new ParallelSearchResult()
                    {
                        word = str,
                        dist = dist,
                        ThreadNum = param.ThreadNum
                    };
                    Result.Add(temp);
                }
            }
            return Result;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
                //Слово для поиска
                string word = this.textBox1.Text.Trim();
                //Если слово для поиска не пусто
                if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
                {
                    int maxDist;
                    if (!int.TryParse(this.textBox2.Text.Trim(), out maxDist))
                    {
                        MessageBox.Show("Необходимо указать максимальное расстояние");
                        return;
                    }
                    if (maxDist < 1 || maxDist > 5)
                    {
                        MessageBox.Show("Максимальное расстояние должно быть в диапазоне от 1 до 5");
                    return;
                    }
                    int ThreadCount;
                    if (!int.TryParse(this.textBox3.Text.Trim(), out ThreadCount))
                    {
                        MessageBox.Show("Необходимо указать количество потоков");
                        return;
                    }
                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    //-------------------------------------------------
                    // Начало параллельного поиска
                    //-------------------------------------------------
                    //Результирующий список
                    List<ParallelSearchResult> Result = new List<ParallelSearchResult>();
                    //Деление списка на фрагменты для параллельного запуска в потоках
                    List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, list.Count,
                   ThreadCount);
                    int count = arrayDivList.Count;
                    //Количество потоков соответствует количеству фрагментов массива
                    Task<List<ParallelSearchResult>>[] tasks = new
                   Task<List<ParallelSearchResult>>[count];
                    //Запуск потоков
                    for (int i = 0; i < count; i++)
                    {
                        //Создание временного списка, чтобы потоки не работали параллельно с
                                            List<string> tempTaskList = list.GetRange(arrayDivList[i].Min,
                        arrayDivList[i].Max - arrayDivList[i].Min);
                                            tasks[i] = new Task<List<ParallelSearchResult>>(
                         //Метод, который будет выполняться в потоке
                         ArrayThreadTask,
                         //Параметры потока
                         new ParallelSearchThreadParam()
                         {
                             tempList = tempTaskList,
                             maxDist = maxDist,
                             ThreadNum = i,
                             wordPattern = word
                         });
                        //Запуск потока
                        tasks[i].Start();
                    }
                    Task.WaitAll(tasks);
                    timer.Stop();
                    //Объединение результатов
                    for (int i = 0; i < count; i++)
                    {
                        Result.AddRange(tasks[i].Result);
                    }
                    //-------------------------------------------------
                    // Завершение параллельного поиска
                    //-------------------------------------------------
                    timer.Stop();
                    //Вывод результатов
                    //Время поиска
                    this.textBox8.Text = timer.Elapsed.ToString();
                    //Вычисленное количество потоков
                    this.textBox4.Text = count.ToString();
                    //Начало обновления списка результатов
                    this.listBox1.BeginUpdate();
                    //Очистка списка
                    this.listBox1.Items.Clear();
                    //Вывод результатов поиска
                    foreach (var x in Result)
                    {
                        string temp = x.word + "(расстояние=" + x.dist.ToString() + " поток="
                       + x.ThreadNum.ToString() + ")";
                        this.listBox1.Items.Add(temp);
                    }
                    //Окончание обновления списка результатов
                    this.listBox1.EndUpdate();
                }
                else
                {
                    MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
                }
            }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Имя файла отчета
            string TempReportFileName = "Report_" +
           DateTime.Now.ToString("dd_MM_yyyy_hhmmss");
            //Диалог сохранения файла отчета
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = TempReportFileName;
            fd.DefaultExt = ".html";
            fd.Filter = "HTML Reports|*.html";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string ReportFileName = fd.FileName;
                //Формирование отчета
                StringBuilder b = new StringBuilder();
                b.AppendLine("<html>");

                b.AppendLine("<head>");
                b.AppendLine("<meta http-equiv='Content-Type' content='text/html; charset = UTF - 8'/>");
               
                b.AppendLine("<title>" + "Отчет: " + ReportFileName + "</title>");
                b.AppendLine("</head>");
                b.AppendLine("<body>");
                b.AppendLine("<h1>" + "Отчет: " + ReportFileName + "</h1>");
                b.AppendLine("<table border='1'>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время чтения из файла</td>");
                b.AppendLine("<td>" + this.textBox6.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Количество уникальных слов в файле</td>");
                b.AppendLine("<td>" + this.textBox8.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Слово для поиска</td>");
                b.AppendLine("<td>" + this.textBox1.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Максимальное расстояние для нечеткого поиска</td>");
                b.AppendLine("<td>" + this.textBox2.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время четкого поиска</td>");
                b.AppendLine("<td>" + this.textBox5.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время нечеткого поиска</td>");
                b.AppendLine("<td>" + this.textBox7.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr valign='top'>");
                b.AppendLine("<td>Результаты поиска</td>");
                b.AppendLine("<td>");
                b.AppendLine("<ul>");
                foreach (var x in this.listBox1.Items)
                {
                    b.AppendLine("<li>" + x.ToString() + "</li>");
                }
                b.AppendLine("</ul>");
                b.AppendLine("</td>");
                b.AppendLine("</tr>");
                b.AppendLine("</table>");
                b.AppendLine("</body>");
                b.AppendLine("</html>");
                //Сохранение файла
                File.AppendAllText(ReportFileName, b.ToString());
                MessageBox.Show("Отчет сформирован. Файл: " + ReportFileName);
            }
        }

    }
}


