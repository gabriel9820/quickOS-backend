﻿namespace quickOS.Core.Entities;

public class Tenant : BaseEntity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    /* Navigation */
    public ICollection<User>? Users { get; private set; }
    public ICollection<ServiceProvided>? ServicesProvided { get; private set; }
    public ICollection<Product>? Products { get; private set; }
    public ICollection<Customer>? Customers { get; private set; }
    public ICollection<ServiceOrder>? ServiceOrders { get; private set; }
    public ICollection<AccountPayable>? AccountsPayable { get; private set; }
    public ICollection<AccountReceivable>? AccountsReceivable { get; private set; }

    private Tenant() { }

    public Tenant(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
