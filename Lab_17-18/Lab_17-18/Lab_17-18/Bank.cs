namespace Lab_17_18
{
    internal class Bank
    {
        private static int idCount = -1;

        public BankAccount CreateBankAccount(string name)
        {
            idCount++;
            return (new BankAccount(idCount.ToString(), name));
        }
    }
}
