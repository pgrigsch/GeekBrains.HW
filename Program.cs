using System;

namespace GeekBrains.HW._1._1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter task number:");
            Console.WriteLine("1: calculate Body Mass Index");
            Console.WriteLine("2: calculate distance");
            Console.WriteLine("3: swap 2 variables");
            Console.WriteLine("4: centered message with name, lastname and city");

            byte selection = Convert.ToByte(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    calculateBMI();
                    break;
                case 2:
                    calculateDistance();
                    break;
                case 3:
                    swap2variables();
                    break;
                case 4:
                    getPersonInfo();
                    break;
                default:
                    Console.WriteLine("unknown task. bye.");
                    break;
            }
            Console.ReadKey();
        }

        static void calculateBMI()
        {
            //1.Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес).В результате вся информация выводится в одну строчку.
            //а) используя склеивание;
            //б) используя форматированный вывод;
            //в) *используя вывод со знаком $.
            Console.Write("Please enter your Name:");
            string personName = Console.ReadLine();
            Console.Write("Please enter your Lastname:");
            string personLastName = Console.ReadLine();
            Console.Write("Please enter your Age:");
            byte personAge = Convert.ToByte(Console.ReadLine());
            Console.Write("Please enter your Height:");
            byte personHeight = Convert.ToByte(Console.ReadLine());
            Console.Write("Please enter your Weight:");
            byte personWeight = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Hello {0} {1}, your age is {2}, your height is {3}, your weight is {4}", personName, personLastName, personAge, personHeight, personWeight);
            Console.WriteLine($"Hello {personName} {personLastName}, your age is {personAge}, your height is {personHeight}, your weight is {personWeight}");
            double personHeightM = Convert.ToDouble(personHeight) / 100;
            double bmi = personWeight / (personHeightM * personHeightM);
            //2.Ввести вес и рост человека. Рассчитать и вывести индекс массы тела(ИМТ) по формуле I = m / (h * h); где m — масса тела в килограммах, h — рост в метрах
            Console.WriteLine($"Your Body Mass Index (BMI) is {bmi,0:F2}");
        }


        static void calculateDistance()
        {
            //Написать программу, которая подсчитывает расстояние между точками с координатами 
            //x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            //Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
            Console.Write("Please enter x1, x2, y1, y2 separated by space: ");
            string phrase = Console.ReadLine();
            string[] words = phrase.Split(' ');
            double x1 = Convert.ToDouble(words[0]);
            double x2 = Convert.ToDouble(words[1]);
            double y1 = Convert.ToDouble(words[2]);
            double y2 = Convert.ToDouble(words[3]);
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"{r,0:F2}");
        }

        static void swap2variables()
        {
            //4.Написать программу обмена значениями двух переменных.
            //а) с использованием третьей переменной;
            //б) *без использования третьей переменной.
            Console.Write("Please enter first var: ");
            string var1 = Console.ReadLine();
            Console.Write("Please enter second var: ");
            string var2 = Console.ReadLine();

            (var1, var2) = (var2, var1);

            Console.WriteLine(var1 + " and " + var2);
        }

        static void getPersonInfo()
        {
            //а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            //б) Сделать задание, только вывод организуйте в центре экрана
            Console.Write("Please enter your Name:");
            string personName = Console.ReadLine();
            Console.Write("Please enter your Lastname:");
            string personLastName = Console.ReadLine();
            Console.Write("Please enter your City:");
            string personCity = Console.ReadLine();
            string msg = $"Your name is {personName} {personLastName}, your city is {personCity}";
            Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
            Console.WriteLine(msg);
        }


    }
}
