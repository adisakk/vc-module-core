using System;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Order.Model
{
    public class CustomerOrderSearchCriteria : SearchCriteriaBase
    {

        public string Keyword { get; set; }

        /// <summary>
        /// Search by numbers
        /// </summary>
        public string Number { get; set; }

        private string[] _numbers;
        public string[] Numbers
        {
            get
            {
                if (_numbers == null && !string.IsNullOrEmpty(Number))
                {
                    _numbers = new[] { Number };
                }
                return _numbers;
            }
            set
            {
                _numbers = value;
            }
        }

        /// <summary>
        /// Search orders with flag IsPrototype
        /// </summary>
        public bool WithPrototypes { get; set; }

        /// <summary>
        /// Search only recurring orders created by subscription
        /// </summary>
        public bool OnlyRecurring { get; set; }

        /// <summary>
        /// Search orders with given subscription
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Search orders with given subscriptions
        /// </summary>
        private string[] _subscriptionIds;
        public string[] SubscriptionIds
        {
            get
            {
                if (_subscriptionIds == null && !string.IsNullOrEmpty(SubscriptionId))
                {
                    _subscriptionIds = new[] { SubscriptionId };
                }
                return _subscriptionIds;
            }
            set
            {
                _subscriptionIds = value;
            }
        }

        /// <summary>
        /// Search by status
        /// </summary>
        public string Status { get; set; }

        private string[] _statuses;
        public string[] Statuses
        {
            get
            {
                if (_statuses == null && !string.IsNullOrEmpty(Status))
                {
                    _statuses = new[] { Status };
                }
                return _statuses;
            }
            set
            {
                _statuses = value;
            }
        }


        /// <summary>
        /// It used to limit search within an operation (customer order for example)
        /// </summary>
        public string OperationId { get; set; }

        public string OrganizationId { get; set; }
        public string CustomerId { get; set; }

        private string[] _customerIds;
        public string[] CustomerIds
        {
            get
            {
                if (_customerIds == null && !string.IsNullOrEmpty(CustomerId))
                {
                    _customerIds = new[] { CustomerId };
                }
                return _customerIds;
            }
            set
            {
                _customerIds = value;
            }
        }

        public string EmployeeId { get; set; }
        public string[] StoreIds { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Search order with product owner
        /// </summary>
        public string ProductOwner { get; set; }

        /// <summary>
        /// Search order with product name
        /// </summary>
        public string ProductName { get; set; }
        public bool ProductNamePartial { get; set; }
    }
}
