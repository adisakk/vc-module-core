﻿using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class RangeFilter : IFilter
    {
        public string FieldName { get; set; }
        public IList<RangeFilterValue> Values { get; set; }
    }
}
