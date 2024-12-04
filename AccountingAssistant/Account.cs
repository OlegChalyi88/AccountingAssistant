namespace AccountingAssistant;

internal class Account : IAccount
{
    private readonly string accountName;
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public Account(string accountName)
    {
        this.accountName = accountName;
    }

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }

    public decimal GetBalance()
    {
        IEnumerable<IncomeTransaction> incomeTransactions = Transactions.OfType<IncomeTransaction>();
        decimal incomeBalance = incomeTransactions.Sum(t => t.Amount);

        IEnumerable<ExpenseTransaction> expenseTransactions = Transactions.OfType<ExpenseTransaction>();
        decimal expenseBalance = expenseTransactions.Sum(t => t.Amount);

        return incomeBalance - expenseBalance;
    }

    public List<T> GetTransactionsByType<T>() where T : Transaction
    {
        
        return Transactions.OfType<T>().ToList();
    }
}
