using Lab_17_18;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        Client client = new Client("Ded Moroz");
        BankAccount bankAccount_01 = bank.CreateBankAccount(client.name);
        //AbstractFabrik
        bankAccount_01.CreateCreditDollarCard(client.name);
        bankAccount_01.CreateCreditBitcoinCard(client.name);
        bankAccount_01.CreateDebitDollarCard(client.name);
        bankAccount_01.CreateDebitBitcoinCard(client.name);

        bankAccount_01.WriteInfoCard();

        client.depositMoneyInTheBankAccounts(bankAccount_01, 100);
        Console.WriteLine(bankAccount_01.ToString());

        //client.BlockedBankAccount(bankAccount_01);
        client.makePayment(bankAccount_01, 10);
        Console.WriteLine(bankAccount_01.ToString());

        Console.WriteLine("--------------------------------------");
        //Prototype
        ICard card_01 = new Card(new CreditDollarFactory(), "Card1");
        ICard card_02 = card_01.Clone();

        card_02.ShowCardInfo();

        //Builder

        Cardener carder = new Cardener();

        CardBuilder builder = new CreditDollarBuilder();

        Console.WriteLine("--------------------------------------");
        Card card_03 = carder.CreateCard(builder);
        card_03.ShowCardInfo();
    }
}