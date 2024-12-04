namespace AccountingAssistant;

internal interface IAccount
{
    public void AddTransaction(Transaction transaction);
    public decimal GetBalance();
    public List<T> GetTransactionsByType<T>() where T : Transaction;
}
