﻿using EPiServer.SpecializedProperties;
using Foundation.AspNetCore.Features.MyOrganization.Shared.Interfaces;
using Foundation.AspNetCore.Features.Shared.Commerce.Customer.Interfaces;
using Foundation.AspNetCore.Infrastructure;

namespace Foundation.AspNetCore.Features.MyOrganization.Shared.Services
{
    public class B2BNavigationService : IB2BNavigationService
    {
        private readonly ICustomerService _customerService;

        public B2BNavigationService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public LinkItemCollection FilterB2BNavigationForCurrentUser(LinkItemCollection b2BLinks)
        {
            var filteredLinks = new LinkItemCollection();
            var currentContact = _customerService.GetCurrentContact();

            foreach (var link in b2BLinks)
            {
                switch (currentContact.B2BUserRole)
                {
                    case B2BUserRoles.Admin:
                        if (Constant.B2BNavigationRoles.Admin.Contains(link.Text))
                        {
                            filteredLinks.Add(link);
                        }

                        break;
                    case B2BUserRoles.Approver:
                        if (Constant.B2BNavigationRoles.Approver.Contains(link.Text))
                        {
                            filteredLinks.Add(link);
                        }

                        break;
                }
            }

            return filteredLinks;
        }
    }
}