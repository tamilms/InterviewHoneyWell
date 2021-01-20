using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinInterviewTask.Views
{
    public class MasterViewPageMenuItem
    {
        public MasterViewPageMenuItem()
        {
            TargetType = typeof(MasterViewPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
