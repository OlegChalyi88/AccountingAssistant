using AccountingAssistant;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("'AccountingAssistant' програму запущено.");

// Створимо екземпляр Account
IAccount account = new Account("УкрНафта");
var date = DateTime.UtcNow.Date;

// Додамо транзакції використовуючи фабричні методи
account.AddTransaction(TransactionFactory.CreateTransaction(TransactionType.Income, date, 423.48923m));
account.AddTransaction(TransactionFactory.CreateTransaction(TransactionType.Expense, date.AddDays(-1), 89.2946735m));
account.AddTransaction(TransactionFactory.CreateTransaction(TransactionType.Expense, new DateTime(2023, 9, 23), 2093.923m));
account.AddTransaction(TransactionFactory.CreateTransaction(TransactionType.Income, new DateTime(2024, 3, 5), 42.89723m));
account.AddTransaction(TransactionFactory.CreateTransaction(TransactionType.Income, date.AddDays(-3), 12.1956923m));
account.AddTransaction(TransactionFactory.CreateTransaction(TransactionType.Expense, date.AddMonths(-2), 63.9436m));
account.AddTransaction(TransactionFactory.CreateTransaction(TransactionType.Income, date.AddYears(-1), 5697.649328m));

// Отримаємо доходи
var totalIncome = account.GetTransactionsByType<IncomeTransaction>();
Console.WriteLine($"Загальний дохід: {totalIncome.Sum(t => t.Amount):C}");
// Отримаємо витрати
var totalExpense = account.GetTransactionsByType<ExpenseTransaction>();
Console.WriteLine($"Загальні витрати: {totalExpense.Sum(t => t.Amount):C}");

// Виведемо баланс у національній валюті
Console.WriteLine($"Загальний баланс: {account.GetBalance():C}");

Console.WriteLine();
Console.WriteLine("З'ясуємо деталі кожної дохідної транзакції");
Console.WriteLine(new string('-', 87));
foreach (var income in totalIncome)
{
    Console.WriteLine(income.GetDetails());
}
Console.WriteLine(new string('-', 87));

Console.WriteLine();
Console.WriteLine("З'ясуємо деталі кожної витратної транзакції");
Console.WriteLine(new string('-', 88)); 
foreach (var expense in totalExpense)
{
    Console.WriteLine(expense.GetDetails());
}
Console.WriteLine(new string('-', 88));

// Delay
Console.ReadKey();
