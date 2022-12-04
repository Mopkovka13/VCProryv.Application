using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCProryv.Core.Repositories
{
    public interface IActivityRepositories
    {
        Task<int> Add(Activity activity);
    }
}
