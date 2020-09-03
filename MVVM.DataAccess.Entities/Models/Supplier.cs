using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

#nullable disable

namespace MVVM.DataAccess.Entities.Models
{
    public partial class Supplier : ValidatableBindableBase
    {
        protected int supplierId;
        protected string companyName;
        protected string contactName;
        protected string contactTitle;
        protected string address;
        protected string city;
        protected string region;
        protected string postalCode;
        protected string country;
        protected string phone;
        protected string fax;
        protected string homePage;

        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public int SupplierId
        {
            get
            {
                return supplierId;
            }
            set
            {
                SetProperty(ref supplierId, value);
            }
        }

        [Required]
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                SetProperty(ref companyName, value);
            }
        }

        [Required]
        public string ContactName
        {
            get
            {
                return contactName;
            }
            set
            {
                SetProperty(ref contactName, value);
            }
        }

        [Required]
        public string ContactTitle
        {
            get
            {
                return contactTitle;
            }
            set
            {
                SetProperty(ref contactTitle, value);
            }
        }

        [Required]
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                SetProperty(ref address, value);
            }
        }

        [Required]
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                SetProperty(ref city, value);
            }
        }

        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                SetProperty(ref region, value);
            }
        }

        [Required]
        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                SetProperty(ref postalCode, value);
            }
        }

        [Required]
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                SetProperty(ref country, value);
            }
        }

        [Required]
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                SetProperty(ref phone, value);
            }
        }

        [Required]
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                SetProperty(ref fax, value);
            }
        }

        public string HomePage
        {
            get
            {
                return homePage;
            }
            set
            {
                SetProperty(ref homePage, value);
            }
        }

        public virtual ICollection<Product> Products { get; set; }


        public override IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            if(string.IsNullOrEmpty(propertyName) || propertyName == nameof(CompanyName))
            {
                if(string.IsNullOrWhiteSpace(companyName))
                {
                    yield return "Name cannot be empty.";
                }
            }
        }
    }
}
