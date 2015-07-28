using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CouponsOnline.BusinessLayer
{
    public interface RecommendStrategy
    {
        DataTable Recommend();
    }
}