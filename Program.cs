using System;

class Fraction
{
    private int numerator;
    private int denumerator;

    public Fraction(int n = 1, int d = 1)
    {
        numerator = n;
        denumerator = d;
    }

    public Fraction plus(Fraction b)
    {
        Fraction c = new Fraction();

        c.numerator = numerator * b.denumerator + denumerator * b.numerator;
        c.denumerator = denumerator * b.denumerator;
        c.simplify();
        return c;
    }

    public Fraction minus(Fraction b)
    {
        Fraction c = new Fraction();
        c.numerator = numerator * b.denumerator - denumerator * b.numerator;
        c.denumerator = denumerator * b.denumerator;
        c.simplify();
        return c;
    }

    public Fraction multiplication(Fraction b)
    {
        Fraction c = new Fraction();
        c.numerator = numerator * b.numerator;
        c.denumerator = denumerator * b.denumerator;
        c.simplify();
        return c;
    }

    public Fraction devide(Fraction b)
    {
        Fraction c = new Fraction();
        c.numerator = numerator * b.denumerator;
        c.denumerator = denumerator * b.numerator;
        c.simplify();

        return c;
    }

    public void simplify()
    {        
        int highest_common_devidor = 0;
        for (int i = 2; i<= Math.Min(numerator, denumerator); i++)
        {
            if (numerator % i == 0 && denumerator % i == 0)
            {
                highest_common_devidor = i;
            }
        }

        if (highest_common_devidor > 0)
        {
            numerator = numerator / highest_common_devidor;
            denumerator = denumerator / highest_common_devidor;            
            simplify();
        }

    }

    public override string ToString()
    {
        return numerator + "/" + denumerator;
    }


}
struct Complex
{
    public double im;
    public double re;
    //  в C# в структурах могут храниться также действия над данными
    public Complex Plus(Complex x)
    {
        Complex y;
        y.im = im + x.im;
        y.re = re + x.re;
        return y;
    }
    public Complex Minus(Complex x)
    {
        Complex y;
        y.im = im - x.im;
        y.re = re - x.re;
        return y;
    }
    //  Пример произведения двух комплексных чисел
    public Complex Multi(Complex x)
    {
        Complex y;
        y.im = re * x.im + im * x.re;
        y.re = re * x.re - im * x.im;
        return y;
    }
    public override string ToString()
    {
        return re + "+" + im + "i";
    }
}
class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("please enter task id:");
        Console.WriteLine("1: complex numbers check plus/minus/mulpiplication");
        Console.WriteLine("2: sum positive numbers (zero to finish)");
        Console.WriteLine("3: Fraction operations");        
        int taskId = Convert.ToInt32(Console.ReadLine());
        switch (taskId)
        {
            case 1:
                checkComplexCalculation();
                break;
            case 2:
                sumPositiveUntilZero();
                break;
            case 3:
                fractions_example();
                break;
            default:
                Console.WriteLine("unknown task");
                break;
        }
        Console.ReadKey();
    }

    public static void checkComplexCalculation()
    {
        Complex complex1;
        complex1.re = 1;
        complex1.im = 1;

        Complex complex2;
        complex2.re = 2;
        complex2.im = 2;

        Complex result = complex1.Plus(complex2);
        Console.WriteLine(result.ToString());
        result = complex1.Multi(complex2);
        Console.WriteLine(result.ToString());

        result = complex1.Minus(complex2);
        Console.WriteLine(result.ToString());
    }

    public static void sumPositiveUntilZero()
    {
        //2.
        //а) С клавиатуры вводятся числа, пока не будет введен 0(каждое число в новой строке).
        //   Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;
        //б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
        //   При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
        double sum = 0;

        while (true)
        {
            Console.WriteLine("please enter one more number, or zero to finish. current sum is {0}", sum);
            string input = Console.ReadLine().Replace(".",",");

            if (double.TryParse(input, out double n))
            {
               if (n == 0)
                {
                    Console.WriteLine("ok, finished. result sum is {0}", sum);
                    return;
                }
                else
                {
                    if (n % 2 == 1 && n > 0)
                    {
                        sum += n;
                    }
                }
            }
            else
            {
                Console.WriteLine($"incorrect number {input}");
            }

        }

    }


    public static void fractions_example()
    {
        //3. * Описать класс дробей -рациональных чисел, являющихся отношением двух целых чисел.
        //Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
        //Написать программу, демонстрирующую все разработанные элементы класса.
        //**Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение
        //ArgumentException("Знаменатель не может быть равен 0");
        //Добавить упрощение дробей. ==> Fractions.simplify();

        Console.WriteLine("Please enter Fraction 1, example: 3/4");
        string[] f1_input = Console.ReadLine().Split("/");
        int n1 = Convert.ToInt32(f1_input[0]);
        int d1 = Convert.ToInt32(f1_input[1]);
        if (d1 == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен 0");
        }
        Fraction f1 = new Fraction(n1, d1);

        Console.WriteLine("Please enter Fraction 2, example: 3/4");

        string[] f2_input = Console.ReadLine().Split("/");
        int n2 = Convert.ToInt32(f2_input[0]);
        int d2 = Convert.ToInt32(f2_input[1]);
        if (d2 == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен 0");
        }
        Fraction f2 = new Fraction(n2, d2);

        Console.WriteLine("please enter opeartion. examle +, -, *, /");
        string operation = Console.ReadLine();
        
        switch (operation)
        {
            case "+":
                Fraction Result = f1.plus(f2);
                Console.WriteLine($"{f1} {operation} {f2} = {Result}");
                break;
            case "-":
                Result = f1.minus(f2);                
                Console.WriteLine($"{f1} {operation} {f2} = {Result}");
                break;
            case "*":
                Result = f1.multiplication(f2);
                Console.WriteLine($"{f1} {operation} {f2} = {Result}");
                break;
            case "/":
                Result = f1.devide(f2);
                Console.WriteLine($"{f1} {operation} {f2} = {Result}");
                break;
            default:
                Console.WriteLine("unknown operation");
                break;
        }
    }  

}
