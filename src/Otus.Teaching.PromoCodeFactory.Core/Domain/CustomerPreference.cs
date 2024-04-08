﻿using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain
{
    public class CustomerPreference : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid PreferenceId { get; set; }
        public virtual Preference Preference { get; set; }
    }
}
