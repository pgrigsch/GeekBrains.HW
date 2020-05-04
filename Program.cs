using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GeekBrains.HW._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select task: ");
            Console.WriteLine("1: minimum from 3 numbers");
            Console.WriteLine("2: count numbers in number");
            Console.WriteLine("3: count positive odds untill 0");
            Console.WriteLine("4: auth (root / GeekBrains)");
            Console.WriteLine("5: Body Mass Index");
            Console.WriteLine("6: Good Numbers Searcher");
            Console.WriteLine("7: from a to b");
            byte selection = Convert.ToByte(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    calculateMin();
                    break;
                case 2:
                    calculateStringLenght();
                    break;
                case 3:
                    calcUntillZero();
                    break;
                case 4:
                    auth();
                    break;
                case 5:
                    calculateBMI();
                    break;
                case 6:
                    calculateGoodNumbers();
                    break;
                case 7:
                    printFromAtoB();
                    break;
                default:
                    Console.WriteLine("Unknown task. Bye.");
                    break;
            }
            Console.ReadKey();
        }

            static void calculateMin()
            {
                //1.Написать метод, возвращающий минимальное из трех чисел.
                Console.Write("Please enter 3 numbers, separated by space: ");
                string phrase = Console.ReadLine();
                string[] words = phrase.Split(' ');
                double number1 = Convert.ToDouble(words[0]);
                double number2 = Convert.ToDouble(words[1]);
                double number3 = Convert.ToDouble(words[2]);
                double min = 0;
                if (number1 < number2 && number1 < number3)
                {
                    min = number1;
                }
                else if (number2 < number1 && number2 < number3)
                {
                    min = number2;
                }
                else
                {
                    min = number3;
                }

                Console.WriteLine(min);
            }

            static void calculateStringLenght()
            {
                //2.Написать метод подсчета количества цифр числа.
                Console.Write("Please enter number : ");
                double number = Convert.ToDouble(Console.ReadLine().Replace('.', ','));

                MatchCollection matches = Regex.Matches(Convert.ToString(number), "[0-9]");
                Console.WriteLine(matches.Count);
            }

            static void calcUntillZero()
        {
            //3.С клавиатуры вводятся числа, пока не будет введен 0.Подсчитать сумму всех нечетных положительных чисел.
            bool finish = false;
            double result = 0;

            while (!finish)
            {
                Console.Write("Please enter number: ");
                double number = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
                if (number == 0)
                {
                    finish = true;
                }else if (number > 0 && number % 2 == 1)
                {
                    result += number;
                }
            }

            Console.WriteLine(result);
        }

        static void auth()
        {
            //4.Реализовать метод проверки логина и пароля.На вход подается логин и пароль. 
            //На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин: root, Password: GeekBrains).
            //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
            //программа пропускает его дальше или не пропускает.С помощью цикла do while ограничить ввод пароля тремя попытками.
            int loginAttempts = 1;
            int maxAttemptsCount = 3;
            do
            {                
                Console.Write("Please enter login: ");
                string login = Console.ReadLine();
                Console.Write("Please enter password: ");
                string password = Console.ReadLine();

                if (checkLoginPassword(login, password))
                {
                    Console.WriteLine("you are successfully logged in.");
                    break;
                }
                else
                {
                    if (loginAttempts < maxAttemptsCount)
                    {
                        Console.WriteLine("wrong login or password. you have " + (maxAttemptsCount - loginAttempts) + " attempts left.");
                        loginAttempts++;
                    }
                    else
                    {
                        Console.WriteLine("Your login attempts is finished. sorry, try to contact your administrator.");
                        break;
                    }
                }

            } while (loginAttempts <= maxAttemptsCount);

        }

        static bool checkLoginPassword(string login, string password)
        {
            if (login == "root" && password == "GeekBrains") return true;
            return false;
        }

        static void calculateBMI()
        {
            //5.а) Написать программу, которая запрашивает массу и рост человека, 
            //     вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
            //  б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.            
            Console.Write("Пожалуйста, введите ваш рост (см):");
            byte personHeight = Convert.ToByte(Console.ReadLine());
            Console.Write("Пожалуйста, введите ваш вес (кг):");
            byte personWeight = Convert.ToByte(Console.ReadLine());
            double personHeightM = Convert.ToDouble(personHeight) / 100;
            double bmi = personWeight / (personHeightM * personHeightM);
            //2.Ввести вес и рост человека. Рассчитать и вывести индекс массы тела(ИМТ) по формуле I = m / (h * h); где m — масса тела в килограммах, h — рост в метрах
            Console.WriteLine($"Ваш индекс массы тела (BMI) составляет {bmi,0:F2}");
            if (bmi <= 16)
            {
                //16 и менее  Выраженный дефицит массы тела
                Console.WriteLine("Выраженный дефицит массы тела");
            }else if (bmi > 16 && bmi <= 18.5){
                //16—18,5 Недостаточная(дефицит) масса тела
                Console.WriteLine("Недостаточная(дефицит) масса тела");
            }else if (bmi > 18.5 && bmi <= 25){
                //18,5—25 Норма
                Console.WriteLine("Норма");
            }else if (bmi > 25 && bmi <= 30){
                //25—30   Избыточная масса тела(предожирение)
                Console.WriteLine("Избыточная масса тела(предожирение)");
            }else if (bmi > 30 && bmi <= 35)
            {
                //30—35   Ожирение
                Console.WriteLine("Ожирение");
            }else if (bmi > 35 && bmi <= 40)
            {
                //35—40   Ожирение резкое
                Console.WriteLine("Ожирение резкое");
            }
            else
            {
                //40 и более  Очень резкое ожирение
                Console.WriteLine("Очень резкое ожирение");
            }
                       
            //рекомендация к похудению или набору веса:
            if (bmi < 18.5)
            {
                double weight_good = 18.5 * personHeightM * personHeightM;
                Console.WriteLine("рекомендуем набрать {0:F2}кг", (weight_good - personWeight));
            }else if (bmi > 25)
            {
                double weight_good = 25 * personHeightM * personHeightM;
                Console.WriteLine("рекомендуем скинуть {0:F2}кг", (personWeight - weight_good));
            }else
            {
                Console.WriteLine("рекомендуем держать текущий вес");
            }
        }

        static void calculateGoodNumbers()
        {
            //6. * Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000.
            //   Хорошим называется число, которое делится на сумму своих цифр.
            //Реализовать подсчет времени выполнения программы, используя структуру DateTime.
            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            int sum;
            int good_counter = 0;
            int old_sum = 0;
            for (int i=1; i<=1000000000; i++)
            {

                //два варианта расчета, calcSumTourbo - считает прибавляя 1 и вычитая количество 9 на окончании старой цифры, второй calcSum просто суммирует все цифры каждый раз
                //found 61574510 good numbers, for 00:01:24.5127861 second
                sum = calcSumTourbo(i, old_sum);

                //found 61574510 good numbers, for 00:05:46.5648986 second
                //sum = calcSum(i);                               
                old_sum = sum;

                if (i % 10000000 == 0)
                {
                    Console.WriteLine(i + ", " + sum + ", " + sw.Elapsed);
                }

                if (i % sum == 0)
                {
                    good_counter++;
                    //Console.WriteLine(i + ", " + sum + ", " + len);
                }

            }
            sw.Stop();
            Console.WriteLine("found {0} good numbers, for {1} second", good_counter, sw.Elapsed);

        }
        static int calcSum(int i)
        {
            string i_string = i.ToString();
            int len = i_string.Length;
            int sum = 0;
            for (int n = 0; n<len; n++)
            {
                sum += Convert.ToInt32(i_string[n].ToString());
            }

            return sum;
        }
        static int calcSumTourbo(int i, int old_sum)
        {
            string i_string_before = (i - 1).ToString();                             
            int len = i_string_before.Length;
            int sum = old_sum;
            //если последняя цифра 9
            if (Convert.ToInt32(i_string_before[i_string_before.Length - 1].ToString()) == 9)
            {                
                //цикл от конца в начало. каждая 9 заменится на 0, соответственно вычитаем 9 из суммы цифр. когда дошли до не 9 - останавливаем цикл.
                for (int n = len - 1; n>=0; n--)
                {
                    if (Convert.ToInt32(i_string_before[n].ToString()) == 9)
                    {
                        sum -= 9;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            sum += 1;                      

            return sum;
        }

        static void printFromAtoB()
        {
            //7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b);
            //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
            Console.Write("Пожалуйста, введите A:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Пожалуйста, введите B:");
            int b = Convert.ToInt32(Console.ReadLine());

            int sum = incr(a, b);

            Console.WriteLine("sum = " + sum);
        }

        static int incr(int a, int b)
        {           
            Console.WriteLine(a);

            int sum = 0;
            if (a <= b)
            {
                sum += a + incr(a + 1, b);
                return sum;
            }
            else
            {
                return 0;
            }

        }





        }    
}
