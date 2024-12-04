namespace AccountingAssistant;

internal abstract class Transaction
{
    public Guid TransactionId { get; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }

    protected Transaction(DateTime date, decimal amount)
    {
        Date = date;
        Amount = amount;
    }

    public virtual string GetDetails()
    {
        return string.Format("| Amount: '{0}' | Date: '{1}' |", Amount, Date.Date);
    }
}
