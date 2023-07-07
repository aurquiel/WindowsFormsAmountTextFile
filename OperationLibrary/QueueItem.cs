using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationLibrary
{
    public class QueueItem
    {
        public decimal CounterPrice { set ; get; } = 0;
        public DataTable Data { set ; get; }

        public QueueItem()
        {
            Data = new DataTable();
            Data.Columns.Add("CODIGO", typeof(string));
            Data.Columns.Add("CANTIDAD", typeof(string));
        }
    }
}
