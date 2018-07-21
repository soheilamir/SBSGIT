using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CompanyAttachmentMap : VersionedClassMap<CompanyAttachment>
    {
        public CompanyAttachmentMap()
        {
            Table("CompanyAttachment");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CompanyItem).Column("COMPANY_ID");
            References(x => x.OrdersItem).Column("ORDER_ID");
            References(x => x.FilesItem).Column("ATTACH_FILE_ID");
            Map(x => x.IsDefect).Column("IS_DEFECT");
            Map(x => x.ReasonOfDefect).Column("REASON_OF_DEFECT");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
