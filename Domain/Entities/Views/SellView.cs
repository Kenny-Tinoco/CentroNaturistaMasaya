﻿namespace Domain.Entities.Views
{
    public partial class SellView : BaseEntity
    {
        public int IdSell { get; set; }
        public int IdEmployee { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}
