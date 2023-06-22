public interface ICalculator
{
    void CalculateInterest(Account account);
}
public class Account
{
    // тип учетной записи
    public string Type { get; set; }

    // баланс учетной записи
    public double Balance { get; set; }

    // процентная ставка
    public double Interest { get; set; }

    public Account(string type, double balance, double interest)
    {
        Type = type;
        Balance = balance;
        Interest = interest;
    }
}
class Program
{
    static void Main(string[] args)
    {
        ClassicCalculator classicCalculator = new ClassicCalculator();
        MoneyCalculator moneyCalculator = new MoneyCalculator();

        var client1 = new Account("Обычный", 900, 5);
        var client2 = new Account("Зарплатный", 4700, 5);

        classicCalculator.CalculateInterest(client1);
        moneyCalculator.CalculateInterest(client2);

        Console.WriteLine(client1.Type + " " + client1.Balance + " " + client1.Interest);
        Console.WriteLine(client2.Type + " " + client2.Balance + " " + client2.Interest);
    }
}
public class ClassicCalculator : ICalculator
{
    public void CalculateInterest(Account account)
    {
        if (account.Type == "Обычный")
        {
            if (account.Balance < 1000)
                account.Interest = account.Balance * 0.2;

            if (account.Balance >= 1000)
                account.Interest = account.Balance * 0.4;
        }
    }
}
public class MoneyCalculator : ICalculator
{
    public void CalculateInterest(Account account)
    {
        if (account.Type == "Зарплатный")
        {
            account.Interest = account.Balance * 0.5;
        }
    }
}