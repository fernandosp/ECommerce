
/// <summary>
/// Customer has to choice how it is going to pay for 
/// </CreditCard> </Debit Card> </Billet>
/// </summary>
namespace ECommerce.Domain
{
    public enum PaymentType
    {
        CreditCard = 1,
        CreditDebit = 2,
        Billet = 3
    }
}
