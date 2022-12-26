using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18
{
    abstract class AbstractFactoryCard
    {
        public abstract CurrencyCard CreateGetCurrency();
        public abstract TypeCard CreateGetType();
    }

    abstract class CurrencyCard
    {
        public abstract void GetCurrency();
    }
    abstract class TypeCard
    {
        public abstract void GetTypeCard();
    }

    class Dollar : CurrencyCard
    {
        public override void GetCurrency()
        {
            Console.WriteLine("Dollar");
        }
    }

    class Euro : CurrencyCard
    {
        public override void GetCurrency()
        {
            Console.WriteLine("Euro");
        }
    }

    class Bitcoin : CurrencyCard
    {
        public override void GetCurrency()
        {
            Console.WriteLine("Bitcoin");
        }
    }

    class CreditCard : TypeCard
    {
        public override void GetTypeCard()
        {
            Console.WriteLine("Credit card");
        }
    }

    class DebitCard : TypeCard
    {
        public override void GetTypeCard()
        {
            Console.WriteLine("Debit Card");
        }
    }

    class CreditDollarFactory : AbstractFactoryCard
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Dollar();
        }

        public override TypeCard CreateGetType()
        {
            return new CreditCard();
        }
    }

    class CreditBitcoinFactory : AbstractFactoryCard
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Bitcoin();
        }

        public override TypeCard CreateGetType()
        {
            return new CreditCard();
        }
    }

    class DebitBitcoinFactory : AbstractFactoryCard
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Bitcoin();
        }

        public override TypeCard CreateGetType()
        {
            return new DebitCard();
        }
    }

    class DebitDollarFactory : AbstractFactoryCard
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Dollar();
        }

        public override TypeCard CreateGetType()
        {
            return new DebitCard();
        }
    }
}
