using Mediachase.BusinessFoundation.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foundation.AspNetCore.Features.Shared.Commerce.Customer.Models
{
    public class FoundationOrganization
    {
        public FoundationOrganization(Mediachase.Commerce.Customers.Organization organization) => OrganizationEntity = organization;

        public Mediachase.Commerce.Customers.Organization OrganizationEntity { get; set; }

        public Guid OrganizationId
        {
            get => OrganizationEntity.PrimaryKeyId ?? Guid.Empty;
            set => OrganizationEntity.PrimaryKeyId = (PrimaryKeyId?)value;
        }

        public string Name
        {
            get => OrganizationEntity.Name;
            set => OrganizationEntity.Name = value;
        }

        public FoundationAddress Address => Addresses != null && Addresses.Any() ? Addresses.FirstOrDefault() : null;

        public List<FoundationAddress> Addresses => OrganizationEntity.Addresses != null && OrganizationEntity.Addresses.Any()
            ? OrganizationEntity.Addresses.Select(address => new FoundationAddress(address)).ToList()
            : new List<FoundationAddress>();

        public List<FoundationOrganization> SubOrganizations => OrganizationEntity.ChildOrganizations.Select(
                        childOrganization => new FoundationOrganization(childOrganization)).ToList();

        public Guid ParentOrganizationId
        {
            get => OrganizationEntity.ParentId ?? Guid.Empty;
            set => OrganizationEntity.ParentId = (PrimaryKeyId?)value;
        }

        public FoundationOrganization ParentOrganization { get; set; }

        public void SaveChanges() => OrganizationEntity.SaveChanges();

        public static FoundationOrganization New() => new FoundationOrganization(Mediachase.Commerce.Customers.Organization.CreateInstance());
    }
}