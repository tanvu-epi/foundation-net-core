﻿using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.PlugIn;
using Foundation.AspNetCore.Cms;
using Foundation.AspNetCore.Features.Shared;
using System.ComponentModel.DataAnnotations;

namespace Foundation.AspNetCore.Features.Home
{
    [ContentType(DisplayName = "Cms Home Page",
        GUID = "452d1812-7385-42c3-8073-c1b7481e7b20",
        Description = "Used for home page of all sites",
        AvailableInEditMode = true,
        GroupName = Global.GroupNames.Content)]
    [ImageUrl("~/icons/cms/pages/home.png")]
    public class HomePage : FoundationPageData
    {
        [CultureSpecific]
        [Display(Name = "Top content area", GroupName = SystemTabNames.Content, Order = 190)]
        public virtual ContentArea TopContentArea { get; set; }

        [CultureSpecific]
        [Display(Name = "Bottom content area", GroupName = SystemTabNames.Content, Order = 210)]
        public virtual ContentArea BottomContentArea { get; set; }

    }

    [PropertyDefinitionTypePlugIn]
    public class SelectionItemProperty : PropertyList<SelectionItem>
    {
    }
}
