﻿using System.Linq;
using Redux;

namespace NorthwindApplication.Customer.Actions
{
    public class OpenCustomer : IAction
    {

        public OpenCustomer(Customer customer, string userId)
        {
            Customer = customer;
            UserId = userId;
        }
        
        public Customer Customer { get; private set; }
        public string UserId { get; private set; }
    }
    
    public class OpenCustomerComplete : IAction
    {
    }
    
    
    
    public class OpenCustomerReducer : ActionReducer<OpenCustomer, CustomerState>
    {
        public override CustomerState Reducer(CustomerState state, OpenCustomer action)
        {
            var item = state.OpenCustomers.FirstOrDefault(oc => oc.Customer.CustomerId == action.Customer.CustomerId)
                       ?? new OpenedCustomer() { Customer = action.Customer } ;

            if (!item.Users.Contains(action.UserId))
            {
                item.Users.Add(action.UserId);
            }

            if (!state.OpenCustomers.Contains(item))
            {
                state.OpenCustomers.Add(item);
            }
            return state;
        }
    }
    
}