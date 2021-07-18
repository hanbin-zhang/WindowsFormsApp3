using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Sql_update_data
    {
        public enum action_type
        {
            add,
            delete,
            alter
        }

        public action_type action_Type { get; set; }

    }
}
