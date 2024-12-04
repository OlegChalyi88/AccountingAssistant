namespace AccountingAssistant;

internal class ExpenseTransaction : Transaction
{
    public ExpenseTransaction(DateTime date, decimal amount)
        : base(date, amount)
    {
    }

    public override string GetDetails()
    {
        return string.Format("| Amount: '{0,15}' | Date: '{1,15}' | transaction type: '{2,5}' |", Amount, Date.Date, TransactionType.Expense);
    }
}
