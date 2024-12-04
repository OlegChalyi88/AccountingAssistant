namespace AccountingAssistant;

internal static class TransactionFactory
{
    internal static Transaction CreateTransaction(TransactionType transactionType, DateTime date, decimal amount)
    {
        if (transactionType == TransactionType.Income)
        {
            return new IncomeTransaction(date, amount);
        }
        
        return new ExpenseTransaction(date, amount);
    }
}
