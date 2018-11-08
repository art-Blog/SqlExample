using System;

namespace SqlExample.Models
{
    /// <summary>
    /// �j�M����
    /// </summary>
    public class SearchCondition
    {
        public bool IsSearchShipCity => !string.IsNullOrEmpty(ShipCity);
        public bool IsSearchEmployeeId => EmployeeId > 0;
        public bool IsSearchOrderDate => OrderDateStart != null && OrderDateEnd != null;

        public int EmployeeId { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDateStart { get; set; }
        public DateTime? OrderDateEnd { get; set; }

        /// <summary> �M�w�έ���SQLHelper </summary>
        public int HelperType { get; set; }
    }
}