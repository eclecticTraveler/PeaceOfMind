namespace PeaceOfMind.Service.Models
{
    public interface ICustomer
    {
        long CustomerID { get; set; }
        string Email { get; set; }
        string UserName { get; set; }
    }
}