﻿using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using System;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCode : BaseEntity
    {
        public string Code { get; set; }
        public string ServiceInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid PartnerManagerId { get; set; }
        public virtual Employee PartnerManager { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid PreferenceId { get; set; }
        public virtual Preference Preference { get; set; }
    }
}