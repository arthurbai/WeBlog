﻿using System;
using System.Linq;
using System.Web.UI.WebControls;
using Sitecore.Modules.WeBlog.Components;
using Sitecore.Modules.WeBlog.Managers;

namespace Sitecore.Modules.WeBlog.WebForms.Layouts
{
    public partial class BlogEntryTags : BaseEntrySublayout
    {
        public IEntryTagsCore EntryTagsCore { get; set; }

        public BlogEntryTags(IEntryTagsCore entryTagsCore = null)
        {
            EntryTagsCore = entryTagsCore ?? new EntryTagsCore(CurrentBlog);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEntry();
        }

        /// <summary>
        /// Loads the entry.
        /// </summary>
        protected virtual void LoadEntry()
        {
            // Load tags
            if (!Sitecore.Context.PageMode.IsExperienceEditorEditing)
            {
                var tags = ManagerFactory.TagManagerInstance.GetTagsForEntry(CurrentEntry);
                var list = LoginViewTags.FindControl("TagList") as ListView;

                if (list != null)
                {
                    list.DataSource = from tag in tags select tag.Name;
                    list.DataBind();
                }
            }
        }
    }
}