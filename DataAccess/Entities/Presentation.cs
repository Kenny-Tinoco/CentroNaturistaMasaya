﻿namespace DataAccess.SqlServerDataSource
{
    public partial class Presentation : BaseEntity
    {
        public int idPresentation { get; set; }
        public string name { get; set; } = null!;
    }
}