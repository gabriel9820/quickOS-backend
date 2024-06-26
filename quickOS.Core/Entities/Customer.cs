using quickOS.Core.Enums;
using quickOS.Core.ValueObjects;

namespace quickOS.Core.Entities;

public class Customer : MultiTenantEntity
{
    public int Code { get; private set; }
    public CustomerType Type { get; private set; }
    public string Document { get; private set; }
    public string FullName { get; private set; }
    public string Cellphone { get; private set; }
    public string Email { get; private set; }
    public bool IsActive { get; private set; }
    public Address Address { get; private set; }

    /* Navigation */
    public ICollection<ServiceOrder>? ServiceOrders { get; private set; }

    private Customer() { }

    public Customer(int code, CustomerType type, string document, string fullName, string cellphone, string email, bool isActive, Address address)
    {
        Code = code;
        Type = type;
        Document = document;
        FullName = fullName;
        Cellphone = cellphone;
        Email = email;
        Address = address;
        IsActive = isActive;
    }

    public void UpdateCode(int code)
    {
        Code = code;
    }

    public void UpdateType(CustomerType type)
    {
        Type = type;
    }

    public void UpdateDocument(string document)
    {
        Document = document;
    }

    public void UpdateFullName(string fullName)
    {
        FullName = fullName;
    }

    public void UpdateCellphone(string cellphone)
    {
        Cellphone = cellphone;
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }

    public void UpdateAddress(Address address)
    {
        Address = address;
    }

    public void UpdateIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}
