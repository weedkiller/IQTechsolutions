using System;
using System.Collections.Generic;
using System.Text;
using Iqt.Base.BaseTypes;

namespace Accounting.Base.Entities
{
    /// <summary>
    /// An account that is part of the chart of accounts in the ledger
    /// </summary>
    public class LedgerAccount : EntityBase
    {
        /// <summary>
        /// Gets or Sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the Description
        /// </summary>
        public string Description { get; set; }
    }
}
