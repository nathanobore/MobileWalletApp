//C# Mobile Wallet App
//This demonstrates a basic wallet app in C# that allows users to:

//1. Add funds
//2. Withdraw funds
//3. Check balance
//4. View transaction history

//MobileWalletApp.cs

using System;
using System.Collections.Generic;

public class MobileWalletApp
{
    private decimal balance;
    private List<Transaction> transactionHistory;

    public WalletApp()
    {
        balance = 0;
        transactionHistory = new List<Transaction>();
    }

    public void AddFunds(decimal amount)
    {
        balance += amount;
        transactionHistory.Add(new Transaction(amount, TransactionType.Deposit));
        Console.WriteLine($"Added {amount} to your wallet.");
    }

    public void WithdrawFunds(decimal amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        balance -= amount;
        transactionHistory.Add(new Transaction(amount, TransactionType.Withdrawal));
        Console.WriteLine($"Withdrew {amount} from your wallet.");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Your current balance is: {balance}");
    }

    public void ViewTransactionHistory()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in transactionHistory)
        {
            Console.WriteLine($"{transaction.Type}: {transaction.Amount}");
        }
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal
}

public class Transaction
{
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }

    public Transaction(decimal amount, TransactionType type)
    {
        Amount = amount;
        Type = type;
    }
}


Program.cs

using System;

class Program
{
    static void Main(string[] args)
    {
        var walletApp = new WalletApp();

        while (true)
        {
            Console.WriteLine("Wallet App Menu:");
            Console.WriteLine("1. Add funds");
            Console.WriteLine("2. Withdraw funds");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. View transaction history");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter amount to add: ");
                    var addAmount = decimal.Parse(Console.ReadLine());
                    walletApp.AddFunds(addAmount);
                    break;
                case "2":
                    Console.Write("Enter amount to withdraw: ");
                    var withdrawAmount = decimal.Parse(Console.ReadLine());
                    walletApp.WithdrawFunds(withdrawAmount);
                    break;
                case "3":
                    walletApp.CheckBalance();
                    break;
                case "4":
                    walletApp.ViewTransactionHistory();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }
}
