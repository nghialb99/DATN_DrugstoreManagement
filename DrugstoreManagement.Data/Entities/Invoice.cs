namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Invoices")]
    public partial class Invoice
    {
        public int id { get; set; }

        [Column(TypeName = "xml")]
        public string? invoiceInfo { get; set; }

        public string? InvoiceNumber;
        [Column(TypeName = "datetime")]
        public DateTime InvoiceIssuedDate;
        public string? UserName; // creator
        public string? SellerLegalName; // Seller
        public string? SellerTaxCode;
        public string? SellerAddressLine;
        public string? SellerPhoneNumber;
        public string? SellerEmail;
        public string? SellerBankName;
        public string? SellerBankAccount;
        public string? SellerWebsite;
        public string? BuyerCode;// Buyer
        public string? BuyerDisplayName;
        public string? BuyerLegalName;
        public string? BuyerTaxCode;
        public string? BuyerAddressLine;
        public string? BuyerPhoneNumber;
        public string? BuyerEmail;
        public string? PaymentMethodName; //
        public decimal? TotalAmount;
        public int Discount;
        public decimal? DiscountAmount;
        public decimal? TotalAmountAfterDiscount;
        public string? TotalAmountInWords;
        public string? InvoiceNote;

        [StringLength(200)]
        public string? reasonDelete { get; set; }

        public bool? status { get; set; }
    }
}
